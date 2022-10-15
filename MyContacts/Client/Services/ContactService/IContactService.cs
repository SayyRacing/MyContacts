using MyContacts.Shared;

namespace MyContacts.Client.Services.ContactService
{
    public interface IContactService
    {
        List<Contact> Contacts { get; set; }

        List<Category> Categories { get; set; }

        Task GetContacts();
        Task GetCategories();
        Task<Contact> GetSingleContact(int id);
    }
}
