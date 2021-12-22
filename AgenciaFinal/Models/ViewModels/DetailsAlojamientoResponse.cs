using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Models.ViewModels
{
    public class DetailsAlojamientoResponse
    {


        public int id { get; set; }

        public string barrio { get; set; }

        public string ciudad { get; set; }
         
        public string estrellas { get; set; }

        public bool tv { get; set; }
       
        public bool esHotel { get; set; }

       public int cantidadDePersonas { get; set; }

        public string imagen { get; set; }
     
        public IFormFile imageFile { get; set; }
        public Hotel hotel { get; set; }
        public Cabania cabania { get; set; }

        public DetailsAlojamientoResponse()
        {
        }



    }
}
