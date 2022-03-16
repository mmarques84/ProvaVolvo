
using Microsoft.EntityFrameworkCore;
using ProvaCaminhao.Models;

namespace ProvaCaminhao.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
           : base(options)
        {
        }

        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
    }
}
