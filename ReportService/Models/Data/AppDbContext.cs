using Microsoft.EntityFrameworkCore;
using ReportService.Models.Entities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ReportService.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Contact> Contracts { get; set; }

    }
}
