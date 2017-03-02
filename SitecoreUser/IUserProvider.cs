
using SitecoreUser.Wrappers;

namespace SitecoreUser
{
    public interface IUserProvider
    {
        string Domain { get; set; }

        string Path { get; set; }

        string Database { get; set; }

        string TemplateId { get; set; }

        void Synchronize();

        void CreateUserItem(IUser p_User,
                            IItem p_ParentItem,
                            ITemplateItem p_Template,
                            IDatabase p_Database);
    }
}
