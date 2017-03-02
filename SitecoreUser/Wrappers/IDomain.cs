using System.Collections.Generic;

namespace SitecoreUser.Wrappers
{
    public interface IDomain
    {
        IEnumerable<IUser> GetUsers();

        IUser GetUser(string p_UserName);
    }
}
