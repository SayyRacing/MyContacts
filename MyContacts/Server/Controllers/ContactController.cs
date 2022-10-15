using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyContacts.Server.Data;

namespace MyContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        //potrzebujemy ContactControllera żeby komunikować się z bazą danych
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }

        //tworzymy nowe obiekty naszych klas
        public static List<Category> categories = new List<Category>
        {
            new Category{Id = 1, Name = "Prywatny"},
            new Category{Id = 2, Name = "Służbowy"},
            new Category{Id = 3, Name = "Inny"}
        };

        public static List<Contact> contacts = new List<Contact> 
        {
            new Contact
            {
                Id = 1,
                FistName = "Charles",
                LastName = "Leclerc",
                Email = "cLeclerc@gmail.com",
                Password = "abc123",
                Category = categories[1],
                CategoryId = 1,
                SubCategory= "",
                PhoneNumber=506432523,
                DateOfBirth = new DateTime(1999,11,21)
                
            },
            new Contact
            {
                Id = 2,
                FistName = "Lewis",
                LastName = "Hamilton",
                Email = "lHam44@gmail.com",
                Password = "abc123",
                Category = categories[2],
                CategoryId= 2,
                SubCategory= "",
                PhoneNumber=677312444,
                DateOfBirth = new DateTime(1981,02,01)

            },
            new Contact
            {
                Id = 3,
                FistName = "Fernando",
                LastName = "Alonso",
                Email = "fAlonso@gmail.com",
                Password = "235634",
                Category = categories[1],
                CategoryId = 1,
                SubCategory= "",
                PhoneNumber=111222145,
                DateOfBirth = new DateTime(1997,10,30)

            }
        };
        

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {

            var contacts = await _context.Contacts.ToListAsync();
            //zwracamy kontakty z kodem ok200
            return Ok(contacts);   
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSingleContact(int id)
        {
            var contact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound("Nie znaleziono kontaktu");
            }    
            return Ok(contact);
        }

        //dodawanie nowego kontaktu
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            contact.Category = null;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            
            return Ok(await GetDbContacts());
        }
        //wywołanie listy wszystkich kontaktów po zapisaniu
        private async Task<List<Contact>> GetDbContacts()
        {
            return await _context.Contacts.Include(c => c.Category).ToListAsync();
        }

        //edycja kontaktu
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact, int id)
        {
            var dbContact = await _context.Contacts
                    .Include(c => c.Category)
                    .FirstOrDefaultAsync(c => c.Id == id);
            if (dbContact == null)
                return NotFound("Nie znaleziono kontaktu");

            dbContact.FistName = contact.FistName;
            dbContact.LastName = contact.LastName;
            dbContact.Email = contact.Email;
            dbContact.CategoryId = contact.CategoryId;

            await _context.SaveChangesAsync();


            return Ok(await GetDbContacts());
        }

        //Usuwanie kontaktu
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var dbContact = await _context.Contacts
                    .Include(c => c.Category)
                    .FirstOrDefaultAsync(c => c.Id == id);
            if (dbContact == null)
                return NotFound("Nie znaleziono kontaktu");

            _context.Contacts.Remove(dbContact);

            await _context.SaveChangesAsync();


            return Ok(await GetDbContacts());
        }
    }
}
