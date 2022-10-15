using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? SubCategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
