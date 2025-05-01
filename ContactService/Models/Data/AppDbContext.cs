using ContactService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }

    }
}
