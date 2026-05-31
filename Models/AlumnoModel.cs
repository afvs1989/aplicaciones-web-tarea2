using System.ComponentModel.DataAnnotations;

namespace tarea2_clientes.Models
{
    public class AlumnoModel
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
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El código debe tener entre 3 y 20 caracteres")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "El código solo puede contener letras y números")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La carrera debe tener entre 3 y 100 caracteres")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, 20, ErrorMessage = "El semestre debe estar entre 1 y 20")]
        [Display(Name = "Semestre")]
        public int Semestre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0, 10, ErrorMessage = "El promedio debe estar entre 0 y 10")]
        [Display(Name = "Promedio")]
        public decimal Promedio { get; set; }

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
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }
    }
}
