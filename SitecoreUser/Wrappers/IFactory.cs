using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreUser.Wrappers
{
    public interface IFactory
    {
        IDomain GetDomain(string p_DomainName);

        IDatabase GetDatabase(string p_DatabaseName);
    }
}
