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

        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime fDesde { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "HASTA")]
        public System.DateTime? fHasta { get; set; }

        public Alojamiento id_alojamiento { get; set; }
       

        public Usuario id_usuario { get; set; }

        [Display(Name = "IMPORTE")]
        public float precio { get; set; }

    }
}
