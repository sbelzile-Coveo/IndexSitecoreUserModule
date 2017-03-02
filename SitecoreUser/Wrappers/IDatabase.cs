namespace SitecoreUser.Wrappers
{
    public interface IDatabase
    {
        IItem GetItem(string p_ItemPath);

        ITemplateItem GetTemplate(string p_Id);

        void DeleteItem(string p_ItemPath);
    }
}
