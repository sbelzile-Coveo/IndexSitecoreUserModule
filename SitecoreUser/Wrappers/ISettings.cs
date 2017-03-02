namespace SitecoreUser.Wrappers
{
    public interface ISettings
    {
        string GetSetting(string p_Name,
                          string p_DefaultValue);
    }
}
