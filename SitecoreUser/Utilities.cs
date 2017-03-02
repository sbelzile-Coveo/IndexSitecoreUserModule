
using System.Linq;
using SitecoreUser.Settings;

namespace SitecoreUser
{
    public class Utilities : IUtilities
    {
        private readonly IUserSynchronizationSettings m_Settings;

        public Utilities()
            : this(new UserSynchronizationSettings())
        {
        }

        public Utilities(IUserSynchronizationSettings p_Settings)
        {
            m_Settings = p_Settings;
        }

        public string GetDomainName(string p_UserName)
        {
            return p_UserName.Split('\\')[0];
        }

        public string GetUserName(string p_UserName)
        {
            return p_UserName.Split('\\')[1];
        }

        public bool IsDomainSupported(string p_DomainName)
        {
            return m_Settings.Domains.Contains(p_DomainName);
        }

        public UserProvider GetUserProvider()
        {
            return new UserProvider {
                Path = m_Settings.OutputPath,
                TemplateId = m_Settings.UserTemplateId
            };
        }
    }
}
