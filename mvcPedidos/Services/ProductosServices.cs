using Microsoft.EntityFrameworkCore;
using mvcPedidos.Data;
using mvcPedidos.Models;

namespace mvcPedidos.Services
{
    public class ProductosServices
    {
        private readonly DBContextPedidos _context;

        //constructor
        public ProductosServices(DBContextPedidos context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ListarProductos()
        {
            List<Producto> lista = await (
                  from p in _context.Productos
                  select new Producto
                  {
                      Id = p.Id,
                      Nombre = p.Nombre,
                      Precio = p.Precio,
                  }
                  ).ToListAsync();
            return lista;
        }


        public async Task<bool> Guardar(Producto producto)
        {
            bool bandera = false;
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            bandera = true;
            return bandera;
        }

        public async Task<Producto> ObtenerProducto(int? id)
        {
            Producto? producto;
            producto = await(
                from p in _context.Productos
                where p.Id== id
                select new Producto
                {
                    Id= p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    ProductosOrden = (
                        from d in _context.Detalles
                        select new DetalleOrden
                        {
                            Id= d.Id,
                            Cantidad= d.Cantidad,
                            OrdenId= d.OrdenId,
                            ProductoId= d.ProductoId
                        }
                    ).ToList()
                }
              ).FirstOrDefaultAsync();
            return producto;
        }

        public async Task<int> Eliminar(int id)
        {
            int resultado;
            Producto? producto = await ObtenerProducto(id);
            if (producto != null)
            {
                if (producto.ProductosOrden != null)
                {
                    if (producto.ProductosOrden.Count.Equals(0))
                    {
                        _context.Remove(producto);
                        await _context.SaveChangesAsync();
                        resultado = 1;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }
                else
                {
                    _context.Remove(producto);
                    await _context.SaveChangesAsync();
                    resultado = 1;

                }
            }
            else
            {
                resultado= 2;
            }
            
            return resultado;
        }
    } 

}
