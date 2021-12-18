using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models.ViewModels
{
    public class BuscadorDeAjolamientoRequest
    {

        public int id { get; set; }
        public string Ciudad { get; set; }
        public DateTime FDesde { get; set; }
        public DateTime FHasta { get; set; }
        public string Alojamiento { get; set; }
        public int CantidadPersonas { get; set; }

      
    }
}
