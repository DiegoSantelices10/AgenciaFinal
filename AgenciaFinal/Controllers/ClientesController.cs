using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext  _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

   
        public IActionResult Index()
        {

            IEnumerable<Cliente> listaClientes = _context.Cliente;
            return View(listaClientes);
        }

        public IActionResult DeleteCliente(int? id)

        {


            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
            TempData["mensaje"] = "El cliente se ha Eliminado correctamente";
            return RedirectToAction("Index");

        }



    }
}
