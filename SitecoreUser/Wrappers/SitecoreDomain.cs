using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Security.Domains;

namespace SitecoreUser.Wrappers
{
    public class SitecoreDomain : IDomain
    {
        private readonly Domain m_Domain;

        public SitecoreDomain(Domain p_SitecoreDomain)
        {
            m_Domain = p_SitecoreDomain;
        }

        public IEnumerable<IUser> GetUsers()
        {
            return m_Domain.GetUsers().Select(user => new SitecoreUser(user));
        }

        public IUser GetUser(string p_UserName)
        {
            return m_Domain.GetUsers()
                           .Where(user => String.Equals(user.LocalName, p_UserName))
                           .Select(user => new SitecoreUser(user))
                           .FirstOrDefault();
        }
    }
}
