using MyContacts.Shared;

namespace MyContacts.Client.Services.ContactService
{
    public interface IContactService
    {
        List<Contact> Contacts { get; set; }

        List<Category> Categories { get; set; }

        Task GetContacts();
        Task GetCategories();

        //taski operacji CRUD
        Task<Contact> GetSingleContact(int id);
        
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);
    }
}
