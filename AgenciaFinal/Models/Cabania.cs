using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgenciaFinal.Models
{
    public class Cabania
    {

        public int id { get; set; }
        [Display(Name = "HABITACIONES")]
        public int habitaciones { get; set; }

        [Display(Name = "BAÑOS")]
        public int banios { get; set; }

        [Display(Name = "PRECIO X DIA")]
        public double precioPorDia { get; set; }

    }
}
