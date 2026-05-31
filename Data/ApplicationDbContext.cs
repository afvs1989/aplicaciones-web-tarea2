using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tarea2_clientes.Models;

namespace tarea2_clientes.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<AlumnoModel> Alumnos { get; set; }
    }    
}
