
using System;
using System.Web.Security;
using SitecoreUser.Settings;
using SitecoreUser.Wrappers;

namespace SitecoreUser.EventHandlers
{
    public class UserSynchronizerEventHandler
    {
        private readonly IEventManager m_EventManager;
        private readonly IFactory m_Factory;
        private readonly IUtilities m_Utilities;
        private readonly IUserSynchronizationSettings m_Settings;

        /// <summary>
        /// Creates a new instance of <see cref="UserSynchronizerEventHandler" />.
        /// </summary>
        public UserSynchronizerEventHandler()
            : this(new SitecoreEventManager(),
                   new SitecoreFactory(),
                   new Utilities(),
                   new UserSynchronizationSettings())
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="UserSynchronizerEventHandler" /> class.
        /// </summary>
        /// <param name="p_EventManager">The <see cref="IEventManager" /> instance.</param>
        /// <param name="p_UserProvider">The <see cref="IUserProvider" /> instance.</param>
        /// <param name="p_Utilities">The <see cref="IUtilities" /> instance.</param>
        /// <param name="p_Settings">The <see cref="IUserSynchronizationSettings" /> instance.</param>
        public UserSynchronizerEventHandler(IEventManager p_EventManager,
                                            IFactory p_Factory,
                                            IUtilities p_Utilities,
                                            IUserSynchronizationSettings p_Settings)
        {
            m_EventManager = p_EventManager;
            m_Factory = p_Factory;
            m_Utilities = p_Utilities;
            m_Settings = p_Settings;
        }

        /// <summary>
        /// Handles the <b>user:created</b> event.
        /// </summary>
        /// <param name="p_Sender">The event sender.</param>
        /// <param name="p_Args">The event arguments.</param>
        public void OnUserCreated(object p_Sender,
                                  EventArgs p_Args)
        {
            MembershipUser user = m_EventManager.ExtractParameter<MembershipUser>(p_Args, 0);
            if (user != null) {
                HandleUserCreated(user.UserName);
            }
        }

        /// <summary>
        /// Handles the <b>user:updated</b> event.
        /// </summary>
        /// <param name="p_Sender">The event sender.</param>
        /// <param name="p_Args">The event arguments.</param>
        public void OnUserUpdated(object p_Sender,
                                  EventArgs p_Args)
        {
            MembershipUser user = m_EventManager.ExtractParameter<MembershipUser>(p_Args, 0);
            if (user != null) {
                HandleUserUpdated(user.UserName);
            }
        }

        /// <summary>
        /// Handles the <b>user:deleted</b> event.
        /// </summary>
        /// <param name="p_Sender">The event sender.</param>
        /// <param name="p_Args">The event arguments.</param>
        public void OnUserDeleted(object p_Sender,
                                  EventArgs p_Args)
        {
            string user = m_EventManager.ExtractParameter<string>(p_Args, 0);
            if (user != null) {
                HandleUserDeleted(user);
            }
        }

        /// <summary>
        /// Handles the <b>user:created</b> event.
        /// </summary>
        /// <param name="p_UserName">The user name for which the event was raised.</param>
        public void HandleUserCreated(string p_UserName)
        {
            UpdateUserItem(p_UserName);
        }

        /// <summary>
        /// Handles the <b>user:updated</b> event.
        /// </summary>
        /// <param name="p_UserName">The user name for which the event was raised.</param>
        public void HandleUserUpdated(string p_UserName)
        {
            UpdateUserItem(p_UserName);
        }

        /// <summary>
        /// Handles the <b>user:deleted</b> event.
        /// </summary>
        /// <param name="p_UserName">The user name for which the event was raised.</param>
        public void HandleUserDeleted(string p_UserName)
        {
            DeleteUserItem(p_UserName);
        }

        private void UpdateUserItem(string p_UserName)
        {
            try {
                string domain = m_Utilities.GetDomainName(p_UserName);

                if (m_Utilities.IsDomainSupported(domain)) {
                    string username = m_Utilities.GetUserName(p_UserName);
                    UserProvider userProvider = m_Utilities.GetUserProvider();
                    IDomain sitecoreDomain = m_Factory.GetDomain(domain);
                    IUser user = sitecoreDomain.GetUser(username);

                    foreach (string databaseName in m_Settings.Databases) {
                        userProvider.Domain = domain;
                        userProvider.Database = databaseName;
                        IDatabase database = m_Factory.GetDatabase(userProvider.Database);
                        IItem parentItem = database.GetItem(userProvider.Path + "/" + userProvider.Domain);
                        ITemplateItem template = database.GetTemplate(userProvider.TemplateId);

                        userProvider.CreateUserItem(user,
                                                    parentItem,
                                                    template,
                                                    database);
                    }
                }
            } catch (Exception exception) {
                // TODO : log exception
            }
        }

        private void DeleteUserItem(string p_UserName)
        {
            try {
                string domain = m_Utilities.GetDomainName(p_UserName);

                if (m_Utilities.IsDomainSupported(domain)) {
                    string username = m_Utilities.GetUserName(p_UserName);

                    foreach (string databaseName in m_Settings.Databases) {
                        IDatabase database = m_Factory.GetDatabase(databaseName);

                        database.DeleteItem(m_Settings.OutputPath + "/" + domain + "/" + username);
                    }
                }
            }
            catch (Exception exception) {
                // TODO : log exception
            }
        }
    }
}
