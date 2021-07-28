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
        public int Id { get; set; }

        [Display(Name = "Ingresa un barrio")]
        public string barrio { get; set; }

        [Display(Name = "Ingresa cantidad de estrellas")]
        public string estrellas { get; set; }

        [Display(Name = "Ingresa N° de personas")]
        public int cantidadDePersonas { get; set; }

        [Display(Name = "Television?")]
        public bool tv { get; set; }

        [Display(Name = "Ingresa una ciudad")]
        public string ciudad { get; set; }

        [Display(Name = "Ingresa N° de habitaciones")]
        public int cantidad_de_habitaciones { get; set; }

        [Display(Name = "Ingresa el precio por dia")]
        public double precio_por_dia { get; set; }

        [Display(Name = "Ingresa precio por persona")]
        public double precio_por_persona { get; set; }

        [Display(Name = "Ingresa N° de baños")]
        public int cantidadDeBanios { get; set; }

        [Display(Name = "Ingresa el tipo de alojamiento")]
        public bool esHotel { get; set; }
    }
}
