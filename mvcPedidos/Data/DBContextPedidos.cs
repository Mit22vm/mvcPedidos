using Microsoft.EntityFrameworkCore;
using mvcPedidos.Models;

namespace mvcPedidos.Data
{
    public class DBContextPedidos: DbContext
    {

        //Constructor 
        public DBContextPedidos(DbContextOptions<DBContextPedidos> options):base(options)
        { 
       
        }
        //Propiedades , una propiedad por cada tabla
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Orden> Ordenes { get; set; }

        public DbSet<DetalleOrden> Detalles { get;set; }


        //Con esto se crean las tablas en la BD, con esos nombres que se le asignan
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Orden>().ToTable("Ordenes");
            modelBuilder.Entity<DetalleOrden>().ToTable("DetallesOrden");

        }
    }
}
