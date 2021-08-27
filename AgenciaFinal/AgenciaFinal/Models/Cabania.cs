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
        public int habitaciones { get; set; }

        [Display(Name = "Baños")]
        public int banios { get; set; }

        [Display(Name = "Precio/dia")]
        public double precioPorDia { get; set; }

    }
}
