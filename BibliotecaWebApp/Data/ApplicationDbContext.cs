using BibliotecaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
    }
}
