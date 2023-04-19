using System.ComponentModel.DataAnnotations;

namespace mvcPedidos.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Identificación")]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(30, ErrorMessage ="El nombre debe tener máximo de 30 caracteres")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(30, ErrorMessage = "El apellido debe tener máximo de 30 caracteres")]


        public string Apellido { get;set; }


        [Display(Name = "Dirección")]

        public string? Direccion { get; set; }

        [Display(Name = "Telefono")]

        public string? Telefono { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Debe ingresar un email valioso")]

        public string? Email { get; set; }

        //Esta es la relacion
        public ICollection<Orden>? ordenes { get; set; }
    }

}
