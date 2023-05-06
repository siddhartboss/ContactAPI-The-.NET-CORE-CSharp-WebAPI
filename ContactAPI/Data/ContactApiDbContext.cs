using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Data
{
    public class ContactApiDbContext : DbContext
    {
        public DbSet<ContactModel> contactModel { get; set; }

        public ContactApiDbContext(DbContextOptions<ContactApiDbContext> options):base(options)
        {

        }
    }
}
