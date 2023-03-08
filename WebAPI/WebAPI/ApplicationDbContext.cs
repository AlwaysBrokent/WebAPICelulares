using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebAPI.Entidades;

namespace WebAPI.Controllers
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Marca> marcas { get; set; }
        public DbSet<Celular> celular { get; set; }

    }
}
