using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcPedidos.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre debe tener máximo a 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor a cero")]
        [Column(TypeName = "Decimal(10,2)")]

        public decimal Precio { get; set; }

        //Lista
        public ICollection<DetalleOrden>? ProductosOrden { get; set; }
    }
}
