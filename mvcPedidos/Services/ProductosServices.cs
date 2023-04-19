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
            _context= context;
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
    }
}
