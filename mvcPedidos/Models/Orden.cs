using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcPedidos.Models
{
    public class Orden
    {

        public int Id { get; set; }

        [DataType(DataType.Date)]

        public DateTime FechaPedido { get; set; }

        [DataType(DataType.Date)]

        public DateTime? FechaEntrega { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        //Lista de relacion
        public ICollection<DetalleOrden>? ProductosOrden { get; set; }

    }
}
