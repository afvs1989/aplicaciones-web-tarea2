using System.ComponentModel.DataAnnotations;

namespace tarea2_clientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage = "Seleccione un tipo de documento válido")]
        [RegularExpression(@"^(CC|CE|TI|PA|NIT)$", ErrorMessage = "Use CC, CE, TI, PA o NIT")]
        [Display(Name = "Tipo de documento")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression(@"^\d{5,15}$", ErrorMessage = "Ingrese un número de documento válido (5 a 15 dígitos)")]
        [Display(Name = "Número de documento")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "La ciudad debe tener entre 2 y 80 caracteres")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese los 10 dígitos de su número celular")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
