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

        [DataType(DataType.Date)]
        [Display(Name = "DESDE")]
        public DateTime? fDesde { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "HASTA")]
        public DateTime? fHasta { get; set; }

        public Alojamiento id_alojamiento { get; set; }
       

        public Usuario id_usuario { get; set; }

        [Display(Name = "IMPORTE")]
        public float precio { get; set; }

    }
}
