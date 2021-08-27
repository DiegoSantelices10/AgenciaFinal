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

<<<<<<< HEAD
        [DataType(DataType.Date)]
        [Display(Name = "DESDE")]
        public DateTime? fDesde { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "HASTA")]
=======
        [Display(Name = "Fecha Desde")]
        [DataType(DataType.Date)]
        public DateTime? fDesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        [DataType(DataType.Date)]
>>>>>>> 640659166fefc69ea3d7fba35c98e6a974c3c1c7
        public DateTime? fHasta { get; set; }
        public int id_alojamientoid { get; set; }
        public Alojamiento id_alojamiento { get; set; }
        public int id_usuarioid { get; set; }
        public Usuario id_usuario { get; set; }
        [Display(Name = "IMPORTE")]
        public float precio { get; set; }

    }
}
