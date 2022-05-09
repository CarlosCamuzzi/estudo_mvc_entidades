using Microsoft.EntityFrameworkCore;
using app_calculadora.Models;

namespace app_calculadora.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Soma> Somas{ get; set; }

        public DbSet<Seta> Seta { get; set; }
    }
}
