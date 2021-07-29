using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models
{
    [Table("Usuario", Schema="dbo")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre de usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "el {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 2)]
        [Display(Name ="Nombre de usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio")]
        [StringLength(50, ErrorMessage = "el {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electronico")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Numero de documento")]
        public string DNI { get; set; }

        
        [DataType(DataType.Text)]
        public int IntentosDeLogueos { get; set; }

        
        [DataType(DataType.Text)]
        public bool Bloqueado { get; set; }

        [DataType(DataType.Text)]
        public bool EsAdmin { get; set; }




    }
}
