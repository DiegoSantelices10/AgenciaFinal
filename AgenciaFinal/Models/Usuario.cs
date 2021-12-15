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
        public int id { get; set; }

        [Required(ErrorMessage ="El nombre de usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "el {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 2)]
        [Display(Name ="USUARIO")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "el {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 2)]
        [Display(Name = "CONTRASEÑA")]
        public string password { get; set; }


        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "CORREO ELECTRONICO")]
        public string correoElectronico { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "DNI")]
        public string DNI { get; set; }

        
        [DataType(DataType.Text)]
        public int intentosDeLogueos { get; set; }


        [Display(Name = "BLOQUEADO")]
        public bool bloqueado { get; set; }

        [Display(Name = "ADMINISTRADOR")]
        public bool esAdmin { get; set; }


        public Usuario()
        {
            
        }
    }
}
