using Sitecore.Data.Items;

namespace SitecoreUser.Wrappers
{
    public class SitecoreTemplateItem : ITemplateItem
    {
        public TemplateItem TemplateItem { get; private set; }

        public SitecoreTemplateItem(TemplateItem p_TemplateItem)
        {
            TemplateItem = p_TemplateItem;
        }
    }
}
