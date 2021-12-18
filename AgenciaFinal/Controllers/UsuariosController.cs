﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaFinal.DataAccess;
using AgenciaFinal.Models;
using AgenciaFinal.Models.ViewModels;
using Microsoft.AspNetCore.Http;


namespace AgenciaFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;


        private static List<BuscadorDeAjolamientoResponse> _BuscadorDeAjolamiento { get; set; }

       
        //PARA LA BUSQUEDA DE ALOJAMIENTOS

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult CerrarSesion()
        {
            //METODO SIN VISTA QUE ROMPE LA SESSION
            return RedirectToAction("Login", "Home");
        }

        //****************************************************************METODOS CONTROLADOR USUARIO DE USUARIO SOLO
        public IEnumerable<Alojamiento> aloja { get; set; }


        public async Task<IActionResult> BusquedaDeAlojamiento()
        {
            ViewBag.itemsCiudad = GetFkCiudad(_context.Ciudades);
            aloja = await _context.Alojamiento
            .Include(c => c.hotel)
            .Include(c => c.cabania)
                .AsNoTracking()
                .ToListAsync();
            return View(aloja);
        }

        public async Task<IActionResult> DetailsAlojamiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamiento = await _context.Alojamiento
                 .Include(c => c.hotel)
                 .Include(c => c.cabania)
                .FirstOrDefaultAsync(m => m.id == id);

            if (alojamiento == null)
            {
                return NotFound();
            }
            return View(alojamiento);
        }

        [HttpGet]
        public IActionResult IndexUsuario()
        {
            List<SelectListItem> ajolamientoText = new List<SelectListItem>();
         
            ajolamientoText.Add(new SelectListItem("hotel", "hotel"));
            ajolamientoText.Add(new SelectListItem("cabania", "cabania"));
            ViewBag.itemsCiudad = GetFkCiudad(_context.Ciudades);
            ViewBag.itemsAlojamiento = ajolamientoText;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> BusquedaDeAlojamiento(BuscadorDeAjolamientoRequest sobrecargaFalsa)
        {

            string ciudad = sobrecargaFalsa.Ciudad;
            string esHotel = sobrecargaFalsa.Alojamiento;
            DateTime? fDesde = sobrecargaFalsa.FDesde;
            DateTime? fHasta = sobrecargaFalsa.FHasta;
            var cantPersonas = sobrecargaFalsa.CantidadPersonas;


           var result = (from alo in _context.Alojamiento
                                     join re in _context.Reserva on alo.id.ToString() equals re.id_alojamiento.id.ToString()
                                     join ciu in _context.Ciudades on alo.ciudad equals ciu.id.ToString()
                                     where
                                     alo.cantidadDePersonas == cantPersonas &&
                                     ciu.id.ToString() == ciudad &&
                                     alo.esHotel == (string.Compare(esHotel, "hotel") == 0)
                                     //&& (re.fDesde == fDesde && re.fHasta == fHasta)

                                     select new BuscadorDeAjolamientoResponse
                                     {
                                         id = alo.id,
                                         Ciudad = ciu.nombre,                                       
                                         barrioAlojamiento = alo.barrio,
                                         estrellas = alo.estrellas + " Estrellas"

                                     }).ToList();

        
            if (result.Count() != 0)
            {                
                _BuscadorDeAjolamiento = result; 
            }
            return RedirectToAction("ResultadoBusqueda", "Usuarios");          
        }

        private List<SelectListItem> GetFkCiudad(DbSet<Ciudades> user)
        {

            var ciudades = (from u in user
                            select new Ciudades
                            {
                                id = u.id,
                                nombre = u.nombre
                            }).ToList();

            List<SelectListItem> itemsciudad = ciudades.ConvertAll(us =>
            {
                return new SelectListItem()
                {
                    Text = us.nombre.ToString(),
                    Value = us.id.ToString(),
                    Selected = false
                };
            });

            return itemsciudad;
        }
        public  IActionResult ResultadoBusqueda()
        {
            List<BuscadorDeAjolamientoResponse> result = null;
            if (_BuscadorDeAjolamiento != null)
            {
                result = _BuscadorDeAjolamiento;
            }
       
           
            return View(result);
        }
        public async Task<IActionResult> MisDatos()
        {

            var usuario = _context.Usuario.Where(u => u.nombre == Global.nombre & u.password == Global.password).FirstOrDefault();

            return View(usuario);
        }

        public async Task<IActionResult> EditUsuario(int? id)
        {

            var usuario = _context.Usuario.Where(u => u.nombre == Global.nombre & u.password == Global.password).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsuario(int id, Usuario usuario)
        {
            var us = usuario;
            var passViejo = Request.Form["passViejo"];
            var passNuevo1 = Request.Form["passNueva"];
            var passNuevo2 = Request.Form["passNueva1"];

            if (id != usuario.id)
            {
                return NotFound();
            }

            if (passNuevo1.ToString() == passNuevo2.ToString())
            {
                usuario.password = passNuevo1;

                Global.nombre = usuario.nombre;
                Global.password = usuario.password;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                TempData["guardado"] = "Usuario Actualizado";
            }
            return RedirectToAction("MisDatos" , "Usuarios");
        }
        public async Task<IActionResult> MisReservas()
        {
            var reservas = _context.Reserva
            .Include(c => c.id_alojamiento)
            .Include(c => c.id_alojamiento.hotel)
            .Include(c => c.id_alojamiento.cabania)
            .Include(c => c.id_usuario).Where(u => u.id_usuario.nombre == Global.nombre & u.id_usuario.password == Global.password);

            if (reservas != null)
            {
                return View(reservas);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarReservar()
        {
            return View();
        }

        //****************************************************************METODOS COTROLADOR ADMINISTRADOR

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            if (TempData["guardado"] != null)
            {
                TempData["guardado"] = "Usuario Actualizado con exito";
            }
            if (TempData["eliminado"] != null)
            {
                TempData["eliminado"] = "Usuario Eliminado con exito";
            }
            if (TempData["creador"] != null)
            {
                TempData["creador"] = "Usuario Creado con exito";
            }
            return View(await _context.Usuario.ToListAsync());
        }



        public async Task<IActionResult> AdminEditUsuario(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var EditUsuario = await _context.Usuario.FindAsync(id);
            if (EditUsuario == null)
            {
                return NotFound();
            }
            return View(EditUsuario);
        }



        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["creador"] = "Usuario creado con exito";
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        */
        


        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
            var us = usuario;
            var passViejo = Request.Form["passViejo"];
            var passNuevo1 = Request.Form["passNueva"];
            var passNuevo2 = Request.Form["passNueva1"];

            if (id != usuario.id)
            {
                return NotFound();
            }
            
                if (passNuevo1.ToString() == passNuevo2.ToString())
                {
                    usuario.password = passNuevo1;

                    Global.nombre = usuario.nombre;
                    Global.password = usuario.password;

                     _context.Update(usuario);
                    await _context.SaveChangesAsync();

                    TempData["guardado"] = "Usuario Actualizado";
                }
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            TempData["eliminado"] = "Usuario Eliminado con exito";
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.id == id);
        }
    }
}
