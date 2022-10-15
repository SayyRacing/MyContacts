using Microsoft.EntityFrameworkCore;

namespace MyContacts.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)   
        {

        }
        //seedujemy dane 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Prywatny" },
            new Category { Id = 2, Name = "Służbowy" },
            new Category { Id = 3, Name = "Inny" }
            );

            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                FistName = "Charles",
                LastName = "Leclerc",
                Email = "cLeclerc@gmail.com",
                Password = "abc123",
                CategoryId = 1,
                SubCategory = "",
                PhoneNumber = 506432523,
                DateOfBirth = new DateTime(1999, 11, 21)

            },
            new Contact
            {
                Id = 2,
                FistName = "Lewis",
                LastName = "Hamilton",
                Email = "lHam44@gmail.com",
                Password = "abc123",
                
                CategoryId = 2,
                SubCategory = "",
                PhoneNumber = 677312444,
                DateOfBirth = new DateTime(1981, 02, 01)

            },
            new Contact
            {
                Id = 3,
                FistName = "Fernando",
                LastName = "Alonso",
                Email = "fAlonso@gmail.com",
                Password = "235634",                
                CategoryId = 1,
                SubCategory = "",
                PhoneNumber = 111222145,
                DateOfBirth = new DateTime(1997, 10, 30)

            }
            
            );
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> categories { get; set; }
    }
}
