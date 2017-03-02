using Sitecore.Data.Items;

namespace SitecoreUser.Wrappers
{
    public class SitecoreItem : IItem
    {
        public Item Item { get; private set; }

        public SitecoreItem(Item p_Item)
        {
            Item = p_Item;
        }

        public IItem AddItem(string p_ItemName,
                             ITemplateItem p_Template)
        {
            return new SitecoreItem(Item.Add(p_ItemName, p_Template.TemplateItem));
        }

        public void BeginEdit()
        {
            Item.Editing.BeginEdit();
        }

        public void CancelEdit()
        {
            Item.Editing.CancelEdit();
        }

        public void EndEdit()
        {
            Item.Editing.EndEdit();
        }

        public void SetField(string p_FieldName,
                             string p_FieldValue)
        {
            Item.Fields[p_FieldName].Value = p_FieldValue;
        }
    }
}
