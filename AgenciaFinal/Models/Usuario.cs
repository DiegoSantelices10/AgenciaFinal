﻿using System;
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
        [Display(Name ="Usuario")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "el {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required(ErrorMessage = "El correo es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electronico")]
        public string correoElectronico { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "DNI")]
        public string DNI { get; set; }

        
        [DataType(DataType.Text)]
        public int intentosDeLogueos { get; set; }


        [Display(Name = "Bloqueado")]
        public bool bloqueado { get; set; }

        [Display(Name = "Administrador")]
        public bool esAdmin { get; set; }




    }
}
