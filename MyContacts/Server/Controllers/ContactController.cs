using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
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
            //zwracamy kontakty z kodem ok200
            return Ok(contacts);   
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            //zwracamy kontakty z kodem ok200
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSingleContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound("Nie znaleziono kontaktu");
            }    
            return Ok(contact);
        }
    }
}
