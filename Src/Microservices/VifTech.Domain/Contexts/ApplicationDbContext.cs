using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VifTech.Domain.Entities;

namespace VifTech.Domain.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Quotation> Quotations { get; set; }
    }
}
