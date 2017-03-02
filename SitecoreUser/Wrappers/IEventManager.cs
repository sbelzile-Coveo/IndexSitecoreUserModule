
using System;

namespace SitecoreUser.Wrappers
{
    public interface IEventManager
    {
        T ExtractParameter<T>(EventArgs p_Args,
                              int p_ArgumentIndex) where T : class;
    }
}
