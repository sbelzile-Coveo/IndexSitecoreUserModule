using System;
using Sitecore.Events;

namespace SitecoreUser.Wrappers
{
    public class SitecoreEventManager : IEventManager
    {
        public T ExtractParameter<T>(EventArgs p_Arguments,
                                        int p_ArgumentIndex) where T : class
        {
            return Event.ExtractParameter<T>(p_Arguments, p_ArgumentIndex);
        }
    }
}
