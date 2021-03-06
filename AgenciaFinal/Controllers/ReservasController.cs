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
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservas

        public IEnumerable<Reserva> reservas { get; set; }
        public async Task<IActionResult> Index()
        {
            if (TempData["reservaeditado"] != null)
            {
                TempData["reservaeditado"] = "Reserva Actualizada con exito";
            }
            if (TempData["reservaeliminada"] != null)
            {
                TempData["reservaeliminada"] = "Reserva Eliminada con exito";
            }
            if (TempData["reservacreada"] != null)
            {
                TempData["reservacreada"] = "Reserva Creada con exito";
            }

            reservas = await _context.Reserva
            .Include(c => c.id_alojamiento)
            .Include(c => c.id_usuario)
                .AsNoTracking()
                .ToListAsync();

            return View(reservas);
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewBag.itemsUsuarios = GetFkUsuarios(_context.Usuario);
            ViewBag.itemsAlojamiento = GetFkAlojamiento(_context.Alojamiento);

            return View();
        }

        private List<SelectListItem> GetFkUsuarios(DbSet<Usuario> user)
        {

            var Usuario = (from u in user
                           select new Usuario
                           {
                               id = u.id,
                               nombre = u.nombre
                           }).ToList();

            List<SelectListItem> itemsUser = Usuario.ConvertAll(us =>
            {
                return new SelectListItem()
                {
                    Text = us.nombre.ToString(),
                    Value = us.id.ToString(),
                    Selected = false
                };
            });

            return itemsUser;
        }

        private List<SelectListItem> GetFkAlojamiento(DbSet<Alojamiento> aloj)
        {

            var alojamiento = (from u in aloj
                               select new Alojamiento
                               {
                                   id = u.id,
                                   barrio = u.barrio
                               }).ToList();

            List<SelectListItem> itemsAloj = alojamiento.ConvertAll(us =>
            {
                return new SelectListItem()
                {
                    Text = us.barrio.ToString(),
                    Value = us.id.ToString(),
                    Selected = false
                };
            });

            return itemsAloj;
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                TempData["reservacreada"] = "Reserva creada con exito";
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {   
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reserva reserva)
        {
            if (id != reserva.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                    TempData["reservaeditado"] = "Reserva modificada con exito";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.id))
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
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            TempData["reservaeliminada"] = "Reserva eliminada con exito";
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.id == id);
        }


        //PARA EL USUARIO
        public async Task<IActionResult> EditUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsuario(int id, Reserva reserva)
        {

            if (id != reserva.id)
            {
                return NotFound();
            }
            var usuario = _context.Usuario.Where(u => u.nombre == Global.nombre & u.password == Global.password).FirstOrDefault();

            reserva.id_usuario = usuario;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                    TempData["reservaeditado"] = "Reserva modificada con exito";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.id))
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
            return View(reserva);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Reservar(int id)
        //{

        //    Alojamiento alojamiento = _context.Alojamiento.Where(a => a.id == id).FirstOrDefault();
        //    Usuario usuario = _context.Usuario.Where(u => u.nombre == Global.nombre & u.password == Global.password).FirstOrDefault();

        //    double precio = 0;

        //    if (alojamiento.hotel != null)
        //    {

        //        precio = alojamiento.hotel.precio_por_persona * Global.cantPersonas;

        //    }
        //    else
        //    {
        //        var cantDias = Global.fDesde.Subtract(Global.fHasta);

        //        precio = alojamiento.cabania.precioPorDia * cantDias.Days;
        //    }


        //    Reserva reserva = new Reserva(Global.fDesde, Global.fDesde, alojamiento, usuario, precio);

        //    _context.Reserva.Add(reserva);
        //    await _context.SaveChangesAsync();
        //    TempData["reservado"] = "Reserva Confirmada";

        //    return RedirectToAction("MisReservas", "Usuarios");
        //}

        [HttpPost]
       public async Task<IActionResult> Reservar(Alojamiento sobrecargaFalsa)
        {
            var lala = sobrecargaFalsa;
           // Alojamiento alojamiento = _context.Alojamiento.Where(a => a.id == id).FirstOrDefault();
            Usuario usuario = _context.Usuario.Where(u => u.nombre == Global.nombre & u.password == Global.password).FirstOrDefault();

            double precio = 0;

            //if (alojamiento.hotel != null)
            //{

            //    precio = alojamiento.hotel.precio_por_persona * Global.cantPersonas;

            //}
            //else
            //{
            //    var cantDias = Global.fDesde.Subtract(Global.fHasta);

            //    precio = alojamiento.cabania.precioPorDia * cantDias.Days;
            //}


            //Reserva reserva = new Reserva(Global.fDesde, Global.fDesde, alojamiento, usuario, precio);

           // _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();
            TempData["reservado"] = "Reserva Confirmada";

            return RedirectToAction("MisReservas", "Usuarios");
        }

    }
}
