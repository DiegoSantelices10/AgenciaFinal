using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;

namespace AgenciaFinal.Controllers
{
    public class AlojamientosController : Controller
    {
        private readonly AppDbContext _context;

        public AlojamientosController(AppDbContext context)
        {
            _context = context;
        }



        public IEnumerable<Alojamiento> aloja { get; set; }
        // GET: Alojamientoes
        public async Task<IActionResult> Index()
        {
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

        public async Task<IActionResult> BusquedaDeAlojamiento()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BusquedaDeAlojamiento(Reserva reserva)
        {

            var a = reserva;

            var aloja = _context.Reserva.Include(c => c.id_alojamiento)
                  .Where(u => u.id_alojamiento.ciudad == reserva.id_alojamiento.ciudad).FirstOrDefault();

            if (aloja != null)
            {
                return View("Index", aloja);

            }
            return View(aloja);
        }

        // GET: Alojamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,barrio,estrellas,cantidadDePersonas,tv,ciudad,cantidad_de_habitaciones,precio_por_dia,precio_por_persona,cantidadDeBanios,esHotel")] Alojamiento alojamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alojamiento);
                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,barrio,estrellas,cantidadDePersonas,tv,ciudad,cantidad_de_habitaciones,precio_por_dia,precio_por_persona,cantidadDeBanios,esHotel")] Alojamiento alojamiento)
        {
            if (id != alojamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamientoExists(alojamiento.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamientoExists(int id)
        {
            return _context.Alojamiento.Any(e => e.Id == id);
        }
    }
}
