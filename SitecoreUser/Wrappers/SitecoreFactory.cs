using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Security.Domains;

namespace SitecoreUser.Wrappers
{
    public class SitecoreFactory : IFactory
    {
        public IDomain GetDomain(string p_DomainName)
        {
            Domain domain = Factory.GetDomain(p_DomainName);
            return domain != null ? new SitecoreDomain(Factory.GetDomain(p_DomainName))
                                  : null;
        }

        public IDatabase GetDatabase(string p_DatabaseName)
        {
            Database database = Factory.GetDatabase(p_DatabaseName);
            return database != null ? new SitecoreDatabase(Factory.GetDatabase(p_DatabaseName))
                                    : null;
        }
    }
}
