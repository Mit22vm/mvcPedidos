using System.ComponentModel.DataAnnotations;

namespace mvcPedidos.Models
{
    public class DetalleOrden
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="La cantidad es requerida")]

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage ="El producto es equerido")]
        [Display(Name ="Código de Producto")]
        public int ProductoId { get; set; }

        public Producto? producto { get; set; }

        [Required(ErrorMessage = "La orden es equerida")]
        [Display(Name = "Código de orden")]
        public int OrdenId { get; set; }

        public Orden? orden { get; set; }

    }
}
