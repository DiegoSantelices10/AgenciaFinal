using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace AgenciaFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext  _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

   

        public IActionResult Index()
        {

            IEnumerable<Usuario> listaUsuarios = _context.Usuario;
            return View(listaUsuarios);
        }

        public IActionResult CambiarContrasenia()
        {

            return View();
        }

       [HttpPost]
        public IActionResult EditUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                TempData["msj"] = "El usuario se ah actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AgregarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                TempData["msj1"] = "El usuario se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditUsuario(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var user = _context.Usuario.Find(id);
            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        public IActionResult DeleteUsuario(int? id)

        {
            var cliente = _context.Usuario.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(cliente);
            _context.SaveChanges();
            TempData["mensaje"] = "El usuario se ha eliminado correctamente";
            return RedirectToAction("Index");

        }





        [HttpPost]
        public IActionResult BuscarUsuario()
        {
            string documento = HttpContext.Request.Form["dni"];

            IEnumerable<Usuario> listaUsuarios;
        
            listaUsuarios = _context.Usuario.Where(u => u.DNI == documento);

            if (listaUsuarios.Count() == 0)
            {
            TempData["UsuarioNoEncontrado"] = "El usuario no ha sido encontrado";
               
                return View("Index", listaUsuarios);

            }

            return View("Index", listaUsuarios);


        }
    }
}



