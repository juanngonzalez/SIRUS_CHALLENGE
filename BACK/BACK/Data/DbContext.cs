using BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace BACK.Data
{
    public class ArticuloDbContext : DbContext
    {
        public ArticuloDbContext(DbContextOptions<ArticuloDbContext> options) : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
