
using System.Collections.Generic;

namespace SitecoreUser.Settings
{
    public interface IUserSynchronizationSettings
    {
        IEnumerable<string> Databases { get; }
        IEnumerable<string> Domains { get; }
        string OutputPath { get; }
        string UserTemplateId { get; }
    }
}
