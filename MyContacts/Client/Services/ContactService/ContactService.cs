using Microsoft.AspNetCore.Components;
using MyContacts.Shared;
using System.Net.Http.Json;

namespace MyContacts.Client.Services.ContactService
{
    public class ContactService : IContactService
    {
        
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        
        //konstruktor HTTP Client
        public ContactService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
           _navigationManager = navigationManager;
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

        public async Task CreateContact(Contact contact)
        {
            var result = await _http.PostAsJsonAsync("api/contact", contact);
            await SetContacts(result);
        }

        private async Task SetContacts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
            _navigationManager.NavigateTo("contacts");
        }

        public async Task UpdateContact(Contact contact)
        {
            var result = await _http.PutAsJsonAsync($"api/contact/{contact.Id}", contact);
            await SetContacts(result);
        }

        public async Task DeleteContact(int id)
        {
            var result = await _http.DeleteAsync($"api/contact/{id}");
            await SetContacts(result);
        }
    }
}       
