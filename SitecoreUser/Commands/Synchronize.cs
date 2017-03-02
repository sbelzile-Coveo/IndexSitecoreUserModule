using Sitecore.Shell.Framework.Commands;
using SitecoreUser.Settings;
using SitecoreUser.Wrappers;

namespace SitecoreUser.Commands
{
    public class Synchronize : Command
    {
        private readonly UserProvider m_UserProvider;
        private readonly IUserSynchronizationSettings m_Settings;

        public Synchronize()
            : this(new UserProvider(),
                   new UserSynchronizationSettings(new SitecoreSettings()))
        {
        }

        public Synchronize(UserProvider p_UserProvider,
                           IUserSynchronizationSettings p_Settings)
        {
            m_UserProvider = p_UserProvider;
            m_Settings = p_Settings;
        }

        public override void Execute(CommandContext p_Context)
        {
            m_UserProvider.Path = m_Settings.OutputPath;
            m_UserProvider.TemplateId = m_Settings.UserTemplateId;

            foreach (string database in m_Settings.Databases) {
                foreach (string domain in m_Settings.Domains) {
                    m_UserProvider.Database = database;
                    m_UserProvider.Domain = domain;
                    m_UserProvider.Synchronize();
                }
            }
        }
    }
}
