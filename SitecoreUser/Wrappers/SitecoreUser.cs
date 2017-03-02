
using Sitecore.Security;
using Sitecore.Security.Accounts;

namespace SitecoreUser.Wrappers
{
    public class SitecoreUser : IUser
    {
        public User User { get; private set; }

        public string Name
        {
            get { return User.LocalName; }
        }

        public string FullName
        {
            get { return User.Profile.FullName; }
        }

        public string Email
        {
            get
            {
                return User.Profile.Email;
            }
        }

        public string Description
        {
            get
            {
                return User.Profile.Comment;
            }
        }

        public UserProfile Profile
        {
            get
            {
                return User.Profile;
            }
        }

        public SitecoreUser(User p_User)
        {
            User = p_User;
        }
    }
}
