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

        [Display(Name = "Fecha Desde")]
        [DataType(DataType.Date)]
        public DateTime? fDesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        [DataType(DataType.Date)]
        public DateTime? fHasta { get; set; }
        public int id_alojamientoid { get; set; }
        public Alojamiento id_alojamiento { get; set; }
        public int id_usuarioid { get; set; }
        public Usuario id_usuario { get; set; }
        [Display(Name = "Precio Total")]
        public float precio { get; set; }

    }
}
