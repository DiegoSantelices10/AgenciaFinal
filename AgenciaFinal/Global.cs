using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AgenciaFinal.Models;

namespace AgenciaFinal
{
    public class Global
    {



        //DATOS DE LOGIN
        public static string nombre { get; set; }

        public static string password { get; set; }

        //DATOS DE BUSQUEDA DE ALOJAMIENTO
        public static Ciudades ciudad { get; set; }
        public static string tipoAlojamiento { get; set; }
        public static DateTime fDesde { get; set; }
        public static DateTime fHasta { get; set; }
        public static int cantPersonas { get; set; }
    
        //RESULTADO DE BUSQUEDA
        public static IEnumerable<AgenciaFinal.Models.Alojamiento> alojamientosFiltrados { get; set; }

    }
}
