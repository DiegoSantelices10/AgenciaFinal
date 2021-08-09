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

        [Display(Name = "Barrio")]
        public string barrio { get; set; }

        [Display(Name = "Estrellas")]
        public string estrellas { get; set; }

        [Display(Name = "N° de Personas")]
        public int cantidadDePersonas { get; set; }

        [Display(Name = "TV")]
        public bool tv { get; set; }

        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Display(Name = "Habitaciones")]
        public int cantidad_de_habitaciones { get; set; }

        [Display(Name = "Precio por dia")]
        public double precio_por_dia { get; set; }

        [Display(Name = "Precio por persona")]
        public double precio_por_persona { get; set; }

        [Display(Name = "Baños")]
        public int cantidadDeBanios { get; set; }

        [Display(Name = "Es Hotel")]
        public bool esHotel { get; set; }
    }
}
