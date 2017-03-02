using Sitecore.Security;

namespace SitecoreUser.Wrappers
{
    public interface IUser
    {
        string Name { get; }
        string FullName { get; }
        string Email { get; }
        string Description { get; }

        UserProfile Profile { get; }
    }
}
