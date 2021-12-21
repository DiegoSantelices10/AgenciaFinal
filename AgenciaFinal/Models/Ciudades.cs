using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models
{
    public class Ciudades
    {
        public int id { get; set; }

        [Display(Name = "Ciudad")]
        public string nombre { get; set; }

        public Ciudades()
        {

        }
    }
}
