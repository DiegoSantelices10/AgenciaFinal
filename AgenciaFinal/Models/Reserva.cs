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
        public int Id { get; set; }

        public int contador { get; set; } = 0;
        public DateTime FDesde { get; set; }
        public DateTime FHasta { get; set; }
        public Alojamiento id_alojamiento { get; set; }
        public Usuario id_usuario { get; set; }
        public float precio { get; set; }
    }
}
