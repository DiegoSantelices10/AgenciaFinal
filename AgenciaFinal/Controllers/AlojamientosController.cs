using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Controllers
{
    public class AlojamientosController : Controller
    {

        private readonly AppDbContext _context;
        public AlojamientosController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BusquedaDeAlojamiento()
        {
            return View();
        }

        public IActionResult CargarDeAlojamiento()
        {
            IEnumerable<Alojamiento> listaAlojamientos = _context.Alojamiento;
            return View(listaAlojamientos);
        }

        [HttpPost]
        public IActionResult CargarAlojamiento(Alojamiento alojamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Alojamiento.Add(alojamiento);
                _context.SaveChanges();
                TempData["msj"] = "El alojamiento se ha actualizado correctamente";
                
            }
            return View();
        }
    }
}
