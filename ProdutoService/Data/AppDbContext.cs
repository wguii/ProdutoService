using Microsoft.EntityFrameworkCore;
using ProdutoService.Models;

namespace ProdutoService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Produtos { get; set; }

    }
}
