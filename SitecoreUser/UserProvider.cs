using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreUser.Pipelines;
using SitecoreUser.Pipelines.EditFieldsPipeline;
using SitecoreUser.Wrappers;

namespace SitecoreUser
{
    public class UserProvider : IUserProvider
    {
        protected IFactory Factory { get; private set; }
        protected IPipelineRunnerHandler PipelineRunnerHandler { get; private set; }

        public string Domain { get; set; }

        public string Path { get; set; }

        public string Database { get; set; }

        public string TemplateId { get; set; }

        public UserProvider()
            : this(new SitecoreFactory(),
                   new PipelineRunnerHandler(new PipelineRunner()))
        {
        }

        public UserProvider(IFactory p_Factory,
                            IPipelineRunnerHandler p_PipelineRunnerHandler)
        {
            Factory = p_Factory;
            PipelineRunnerHandler = p_PipelineRunnerHandler;
        }

        public void Synchronize()
        {
            IDomain domain = Factory.GetDomain(Domain);

            IEnumerable<IUser> users = domain.GetUsers();

            if (users.Any()) {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    IDatabase database = Factory.GetDatabase(Database);
                    IItem parentItem = GetItem(database, Path + "/" + Domain);
                    ITemplateItem template = database.GetTemplate(TemplateId);

                    foreach (IUser user in users) {
                        CreateUserItem(user,
                                       parentItem,
                                       template,
                                       database);
                    }
                }
            }
        }

        public void CreateUserItem(IUser p_User,
                                   IItem p_ParentItem,
                                   ITemplateItem p_Template,
                                   IDatabase p_Database)
        {
            IItem item = p_Database.GetItem(Path + "/" + Domain + "/" + p_User.Name) ?? p_ParentItem.AddItem(p_User.Name, p_Template);

            RunEditFieldPipeline(item, p_User);
        }

        private void RunEditFieldPipeline(IItem p_Item,
                                          IUser p_User)
        {
            p_Item.BeginEdit();
            try
            {
                EditFieldsPipelineArgs args = new EditFieldsPipelineArgs(p_Item,
                                                                         p_User);
                PipelineRunnerHandler.RunPipeline(args);
                p_Item.EndEdit();
            } catch (Exception exception) {
                // TODO: Log Exception

                p_Item.CancelEdit();
            }
        }

        private IItem GetItem(IDatabase p_Database,
                              string p_Path)
        {
            // TODO : Coder ça moins croche
            string[] path = p_Path.Split('/');
            string p_CurrentPath = path[0];
            IItem parentItem = p_Database.GetItem(p_CurrentPath);
            ITemplateItem folderTemplate = p_Database.GetTemplate(UserSynchronizerConstants.FOLDER_TEMPLATE_ID);

            for (int i = 1; i < path.Count(); i++) {
                p_CurrentPath = p_CurrentPath + '/' + path[i];
                IItem currentItem = p_Database.GetItem(p_CurrentPath);
                if (currentItem == null) {
                    currentItem = parentItem.AddItem(path[i], folderTemplate);
                }
                parentItem = currentItem;
            }

            return p_Database.GetItem(p_Path);
        }
    }
}
