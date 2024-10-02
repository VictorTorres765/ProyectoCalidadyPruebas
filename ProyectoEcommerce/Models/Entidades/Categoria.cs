using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //SOLO PERMITE INGRESAR LETRAS, NO NÚMEROS NI CARACTERES ESPECIALES 
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo {0} solo puede contener letras.")]
        public string Nombre { get; set; }
    }
}
