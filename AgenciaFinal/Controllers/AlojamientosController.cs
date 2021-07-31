using AgenciaFinal.DataAccess;
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
        public IActionResult CargarAlojamiento()
        {
            return View();
        }
    }
}
