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

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime fDesde { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "HASTA")]
        public System.DateTime? fHasta { get; set; }

        public Alojamiento id_alojamiento { get; set; }
       

        public Usuario id_usuario { get; set; }

        [Display(Name = "IMPORTE")]
        public double precio { get; set; }

        public Reserva()
        {

        }

        public Reserva(DateTime fDesde, DateTime? fHasta, Alojamiento id_alojamiento, Usuario id_usuario, double precio)
        {
            this.fDesde = fDesde;
            this.fHasta = fHasta;
            this.id_alojamiento = id_alojamiento;
            this.id_usuario = id_usuario;
            this.precio = precio;
        }
    }
}
