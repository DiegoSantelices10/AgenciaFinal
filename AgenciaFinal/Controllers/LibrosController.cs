using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _context;
        public LibrosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }
        public IActionResult Create()
        {
            return View();
        }


        //Post Create
        [HttpPost]
        public IActionResult Create(Libro libro)

        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }


        // Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null|| id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if(libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }




        [HttpPost]
        public IActionResult Edit(Libro libro)

        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha Actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        //get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        public IActionResult DeleteLibro(int? id)

        {
            

            var libro = _context.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }


            
                _context.Libro.Remove(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha Eliminado correctamente";
                return RedirectToAction("Index");
            

          
        }


    }
}
