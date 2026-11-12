using Microsoft.EntityFrameworkCore;
using Productos_MC_Lib.Entidades;
using Productos_MC_Lib.Interfaces;

namespace Productos_MC_Lib.Entidades.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion IConexion;

        public ProductosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.id== 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.id== 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Productos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            return this.IConexion.Productos!
                .Where(x => x.nombre!.Contains(entidad.nombre!))
                .ToList();
        }

        public List<Productos> Consultar()
        {
            return this.IConexion.Productos!.Take(5).ToList();
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.id!= 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Productos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Productos entidad)
        {
            return string.IsNullOrEmpty(entidad.codigo) ||
                string.IsNullOrEmpty(entidad.nombre) ||
                entidad.precio >= 0 ||
                string.IsNullOrEmpty(entidad.descripcion);
        }
    }
}