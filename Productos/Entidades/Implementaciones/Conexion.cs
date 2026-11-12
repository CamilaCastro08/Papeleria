using Microsoft.EntityFrameworkCore;
using Productos_MC_Lib.Entidades;
using Productos_MC_Lib.Interfaces;
using Productos_MC_Lib.nucleo;

namespace Productos_MC_Lib.Entidades.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Productos>? Productos { get; set; }
    }
}
