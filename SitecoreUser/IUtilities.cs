
namespace SitecoreUser
{
    public interface IUtilities
    {
        string GetDomainName(string p_UserName);

        string GetUserName(string p_UserName);

        bool IsDomainSupported(string p_DomainName);

        UserProvider GetUserProvider();
    }
}
