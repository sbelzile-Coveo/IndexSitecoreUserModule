using System.Collections.Generic;
using SitecoreUser.Wrappers;

namespace SitecoreUser.Settings
{
    public class UserSynchronizationSettings : IUserSynchronizationSettings
    {
        private readonly ISettings m_Settings;

        public IEnumerable<string> Databases
        {
            get
            {
                return m_Settings.GetSetting(SettingsConstants.DATABASE_NAMES_SETTING_NAME, "")
                                 .Split(',');
            }
        }

        public IEnumerable<string> Domains
        {
            get
            {
                return m_Settings.GetSetting(SettingsConstants.DOMAIN_NAMES_SETTING_NAME, "")
                                 .Split(',');
            }
        }

        public string OutputPath
        {
            get
            {
                return m_Settings.GetSetting(SettingsConstants.OUTPUT_PATH_SETTING_NAME, "");
            }
        }

        public string UserTemplateId
        {
            get
            {
                return m_Settings.GetSetting(SettingsConstants.USER_TEMPLATE_ID_SETTING_NAME, "");
            }
        }

        public UserSynchronizationSettings()
            : this(new SitecoreSettings())
        {
        }

        public UserSynchronizationSettings(ISettings p_Settings)
        {
            m_Settings = p_Settings;
        }
    }
}
