using Microsoft.EntityFrameworkCore;
using WebAPI_Saturno.Models;

namespace WebAPI_Saturno.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<TelefoneModel> Telefones { get; set; }
    }
}
