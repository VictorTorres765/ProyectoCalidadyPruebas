using ProyectoEcommerce.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models
{
    public class UsuarioViewModel : Usuario
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no son iguales.")]
        [Display(Name = "Confirmación de contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "Debes ingresar un número de teléfono válido.")]
        [MaxLength(9, ErrorMessage = "El número de teléfono no puede exceder los {1} caracteres.")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        public override string PhoneNumber { get; set; }

    }
}
