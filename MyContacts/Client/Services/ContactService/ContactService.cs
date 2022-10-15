using MyContacts.Shared;
using System.Net.Http.Json;

namespace MyContacts.Client.Services.ContactService
{
    public class ContactService : IContactService
    {
        
        private readonly HttpClient _http;

        //konstruktor HTTP Client
        public ContactService(HttpClient http)
        {
            _http = http;
        }

        public List<Contact> Contacts { get; set; } = new List<Contact>();  
        public List<Category> Categories { get; set; } = new List<Category>(); 

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/contact/categories");
            if (result != null)
                Categories = result;
        }

        public async Task<Contact> GetSingleContact(int id)
        {
            var result = await _http.GetFromJsonAsync<Contact>($"api/contact/{id}");
            if (result != null)
                return result;
            throw new Exception("Nie znaleziono kontaktu");
        }

        public async Task GetContacts()
        {
            //pozyskanie listy wszystkich kontaktów
            var result = await _http.GetFromJsonAsync<List<Contact>>("api/contact");
            if(result != null)
                Contacts = result;
        }

        
    }
}
