using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgenciaFinal.Models
{
    public class Hotel
    {
        public int id { get; set; }

        [Display(Name = "Precio/Persona")]
        public double precio_por_persona { get; set; }
    }
}
