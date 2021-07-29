using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult DeleteUsuario(int? id)

        {
            var cliente = _context.Usuario.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(cliente);
            _context.SaveChanges();
            TempData["mensaje"] = "El usuario se ha Eliminado correctamente";
            return RedirectToAction("Index");

        }



    }
}
