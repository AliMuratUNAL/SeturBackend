using DataAcess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Models.Data.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Report> Reports { get; set; }

    }
}
