
namespace SitecoreUser.Wrappers
{
    public class SitecoreSettings : ISettings
    {
        public string GetSetting(string p_Name,
                                 string p_DefaultValue)
        {
            return Sitecore.Configuration.Settings.GetSetting(p_Name, p_DefaultValue);
        }
    }
}
