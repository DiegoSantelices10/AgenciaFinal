using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgenciaFinal.Models
{
    public class Reserva
    {
        [Key]
        [Display(Name = "ID")]
        
        public int id { get; set; }

        public int contador { get; set; } = 0;
        [Display(Name = "Fecha Desde")]
        public DateTime fDesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        public DateTime fHasta { get; set; }
        public Alojamiento id_alojamiento { get; set; }
        public Usuario id_usuario { get; set; }
        [Display(Name = "Precio Total")]
        public float precio { get; set; }
        public float pDesde { get; set; }
        public float pHasta { get; set; }

    }
}
