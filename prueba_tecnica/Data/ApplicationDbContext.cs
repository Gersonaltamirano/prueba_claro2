using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Models;

namespace prueba_tecnica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
