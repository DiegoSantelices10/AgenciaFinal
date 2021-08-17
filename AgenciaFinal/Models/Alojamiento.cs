using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgenciaFinal.Models
{
    public class Alojamiento
    {

        [Key]
        [Display(Name = "ID Alojamiento")]

        public int id { get; set; }

        [Display(Name = "Barrio")]
        public string barrio { get; set; }

        [Display(Name = "Estrellas")]
        public string estrellas { get; set; }


        [Display(Name = "TV")]
        public bool tv { get; set; }

        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }


        [Display(Name = "Es Hotel")]
        public bool esHotel { get; set; }

        public int cantidadDePersonas { get; set; }

        public string imagen { get; set; }
        public Hotel hotel { get; set; }
        public Cabania cabania { get; set; }
    }
}
