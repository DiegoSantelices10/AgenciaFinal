using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models.ViewModels
{
    public class BuscadorDeAjolamientoResponse
    {

        public int id { get; set; }
        public string Ciudad { get; set; }      
        public string barrioAlojamiento { get; set; }
        public string estrellas { get; set; }
    }
}
