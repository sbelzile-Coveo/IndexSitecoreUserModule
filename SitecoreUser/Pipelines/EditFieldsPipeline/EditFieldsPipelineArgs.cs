
using Sitecore.Pipelines;
using SitecoreUser.Wrappers;

namespace SitecoreUser.Pipelines.EditFieldsPipeline
{
    public class EditFieldsPipelineArgs : PipelineArgs, IPipelineArgs
    {
        public const string EDIT_FIELDS_PIPELINE_NAME = "userSynchronizer.EditUserFields";

        public IItem Item { get; private set; }
        public IUser User { get; private set; }

        public string PipelineName { get; private set; }

        public EditFieldsPipelineArgs(IItem p_Item,
                                      IUser p_User)
        {
            Item = p_Item;
            User = p_User;

            PipelineName = EDIT_FIELDS_PIPELINE_NAME;
        }
    }
}
