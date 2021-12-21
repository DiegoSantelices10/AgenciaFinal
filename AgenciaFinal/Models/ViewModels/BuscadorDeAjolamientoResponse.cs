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
        public string imagen { get; set; }




        //reserva       
        public int idReserva { get; set; } 
        public DateTime fDesde { get; set; }   
        public System.DateTime? fHasta { get; set; }
        public string id_alojamiento { get; set; }
        public string id_usuario { get; set; }      
        public double precio { get; set; }




    }
}
