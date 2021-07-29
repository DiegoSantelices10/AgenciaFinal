
using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }



        public IActionResult Registro()
        {
            return View();
        }



        //Post Create
        [HttpPost]
        public IActionResult Registro(Usuario usuario)

        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                TempData["registro"] = "El usuario se ha creado correctamente";
                return RedirectToAction("Login");
            }
            return View();
        }


      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            var user = _context.Usuario.Where(u => u.Nombre == usuario.Nombre & u.Password == usuario.Password).FirstOrDefault();
            
            if (user != null)
            { 
                if (!user.EsAdmin)
                {
                return RedirectToAction("BusquedaDeAlojamiento", "Alojamientos");
                } else {
            }
                return RedirectToAction("Index", "Usuarios");
            } else
            {
                return RedirectToAction("Login", "Home");
            }


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
