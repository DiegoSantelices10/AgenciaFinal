using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models
{
    public class Cabania
    {

        public int id { get; set; }
        public double habitaciones { get; set; }
        public string barrios { get; set; }
        public int banios { get; set; }
        public Alojamiento id_alojamiento { get; set; }


    }
}
