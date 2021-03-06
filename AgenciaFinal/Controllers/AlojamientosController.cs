using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AgenciaFinal.Controllers
{
    public class AlojamientosController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AppDbContext _context;


        public AlojamientosController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }


        public IEnumerable<Alojamiento> aloja { get; set; }
        // GET: Alojamientoes
        public async Task<IActionResult> Index()
        {
            if (TempData["alojeditado"] != null)
            {
                TempData["alojeditado"] = "Alojamiento Actualizado con exito";
            }
            if (TempData["alojeliminado"] != null)
            {
                TempData["alojeliminado"] = "Alojamiento Eliminado con exito";
            }
            if (TempData["alojcreado"] != null)
            {
                TempData["alojcreado"] = "Alojamiento Creado con exito";
            }
            aloja = await _context.Alojamiento
            .Include(c => c.hotel)
            .Include(c => c.cabania)
                .AsNoTracking()
                .ToListAsync();
            return View(aloja);
        }

        public async Task<IActionResult> Listado()
        {
            return View(await _context.Alojamiento.ToListAsync());
        }

      
        // GET: Alojamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                .FirstOrDefaultAsync(m => m.id == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // GET: Alojamientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alojamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alojamiento alojamiento)
        {


            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(alojamiento.imageFile.FileName);
                string extension = Path.GetExtension(alojamiento.imageFile.FileName);
                alojamiento.imagen = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await alojamiento.imageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(alojamiento);
                await _context.SaveChangesAsync();
                TempData["alojcreado"] = "Alojamiento creado con exito";
                return RedirectToAction(nameof(Index));
            }
    
            return View(alojamiento);
        }

        // GET: Alojamientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento.FindAsync(id);
            if (alojamiento == null)
            {
                return NotFound();
            }
            return View(alojamiento);
        }

        // POST: Alojamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Alojamiento alojamiento)
        {
            if (id != alojamiento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamiento);
                    await _context.SaveChangesAsync();
                    TempData["alojeditado"] = "Alojamiento modificado con exito";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamientoExists(alojamiento.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alojamiento);
        }

        // GET: Alojamientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                .FirstOrDefaultAsync(m => m.id == id);
            if (alojamiento == null)
            {
                return NotFound();
            }

            return View(alojamiento);
        }

        // POST: Alojamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamiento = await _context.Alojamiento.FindAsync(id);
            _context.Alojamiento.Remove(alojamiento);
            await _context.SaveChangesAsync();
            TempData["alojeliminado"] = "Alojamiento eliminado con exito";
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamientoExists(int id)
        {
            return _context.Alojamiento.Any(e => e.id == id);
        }




        







    }
}
