using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaFinal.Models
{
    public class Alojamiento
    {


        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "BARRIO")]
        public string barrio { get; set; }

        [Display(Name = "CIUDAD")]
        public Ciudades ciudad { get; set; }
        

        [Display(Name = "ESTRELLAS")]
        public string estrellas { get; set; }


        [Display(Name = "TV")]
        public bool tv { get; set; }

        [Display(Name = "Es Hotel")]
        public bool esHotel { get; set; }

        [Display(Name = "CANTIDAD DE PERSONAS")]
        public int cantidadDePersonas { get; set; }

        [Display(Name = "Nombre de imagen")]
        public string imagen { get; set; }

        [NotMapped]
        public IFormFile imageFile { get; set; }
        public Hotel hotel { get; set; }
        public Cabania cabania { get; set; }

        public Alojamiento () {
        }
        
    }
}
