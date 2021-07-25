using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;
        public ReservasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Reserva> listaReservas = _context.Reserva;
            return View(listaReservas);
        }
    }
}
