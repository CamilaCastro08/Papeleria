using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Productos_MC_Lib.Entidades;

namespace Productos_MC_Lib.Interfaces
{
    public interface IConexion
    {
        DbSet<Productos>? Productos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
