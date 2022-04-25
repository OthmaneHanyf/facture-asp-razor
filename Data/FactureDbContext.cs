using facture.Models;
using Microsoft.EntityFrameworkCore;

namespace facture.Data
{
    public class FactureDbContext: DbContext
    {
        public FactureDbContext(DbContextOptions<FactureDbContext> options) : base(options)
        {

        }

        public DbSet<Facture> Factures { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}