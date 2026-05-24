using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace tarea2_clientes.Models
{
    public class ClienteModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Direccion { get; set; }
        [MaxLength(10, ErrorMessage ="Ingrese los 10 digitos de su número celular")] 
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
