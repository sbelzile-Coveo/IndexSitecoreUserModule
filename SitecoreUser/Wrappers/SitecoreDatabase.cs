using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Express;

namespace SitecoreUser.Wrappers
{
    public class SitecoreDatabase : IDatabase
    {
        private Database m_Database;

        public SitecoreDatabase(Database p_Database)
        {
            m_Database = p_Database;
        }

        public IItem GetItem(string p_ItemPath)
        {
            Item item = m_Database.Items[p_ItemPath];
            return item != null ? new SitecoreItem(item)
                                : null;
        }

        public ITemplateItem GetTemplate(string p_Id)
        {
            ID id = new ID(p_Id);
            return new SitecoreTemplateItem(m_Database.GetTemplate(id));
        }

        public void DeleteItem(string p_ItemPath)
        {
            Item item = m_Database.Items[p_ItemPath];
            if (item != null) {
                item.Delete();
            }
        }
    }
}
