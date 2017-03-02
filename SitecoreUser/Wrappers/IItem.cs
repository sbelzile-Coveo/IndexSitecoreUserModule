
using Sitecore.Data.Items;

namespace SitecoreUser.Wrappers
{
    public interface IItem
    {
        Item Item { get; }

        IItem AddItem(string p_ItemName,
                      ITemplateItem p_Template);

        void BeginEdit();
        void CancelEdit();
        void EndEdit();

        void SetField(string p_FieldName,
                      string p_FieldValue);
    }
}
