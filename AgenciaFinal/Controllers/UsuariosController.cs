﻿using System;
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
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        //PARA LA BUSQUEDA DE ALOJAMIENTOS

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CerrarSesion()
        {
            //METODO SIN VISTA QUE ROMPE LA SESSION
             return RedirectToAction("Login", "Home");
        }

        //****************************************************************METODOS CONTROLADOR USUARIO DE USUARIO SOLO
        public IEnumerable<Alojamiento> aloja { get; set; }


        public async Task<IActionResult> BusquedaDeAlojamiento()
        {
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

        public async Task<IActionResult> IndexUsuario()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> BusquedaDeAlojamiento(Alojamiento sobrecargaFalsa)
        {
            string ciudad = Request.Form["ciudad"];
            var esHotel = Request.Form["esHotel"];
            DateTime fDesde = DateTime.Parse(Request.Form["fDesde"]);
            DateTime fHasta = DateTime.Parse(Request.Form["fHasta"]);
            var cantPersonas = int.Parse(Request.Form["cantPersonas"]);


            List<AgenciaFinal.Models.Reserva> reservasList = new List<AgenciaFinal.Models.Reserva>();

            List<AgenciaFinal.Models.Alojamiento> alojamientosList = new List<AgenciaFinal.Models.Alojamiento>();

            List<AgenciaFinal.Models.Alojamiento> alojamientosFiltrados = new List<AgenciaFinal.Models.Alojamiento>();

            List<AgenciaFinal.Models.Reserva> reservasFiltradas = new List<AgenciaFinal.Models.Reserva>();

            List<AgenciaFinal.Models.Alojamiento> resultadoDeBusqueda = new List<AgenciaFinal.Models.Alojamiento>();


            IEnumerable<AgenciaFinal.Models.Alojamiento> alojamientos = await _context.Alojamiento
                .Include(c => c.hotel)
                .Include(c => c.cabania)
                    .AsNoTracking()
                    .ToListAsync();

            IEnumerable<AgenciaFinal.Models.Reserva> reservas = await _context.Reserva
            .Include(c => c.id_alojamiento)
            .Include(c => c.id_usuario)
                .AsNoTracking()
                .ToListAsync();



            foreach (AgenciaFinal.Models.Alojamiento alojamiento in alojamientos)
            {
                alojamientosList.Add(alojamiento);
                alojamientosFiltrados.Add(alojamiento);
            }

            foreach (AgenciaFinal.Models.Reserva reserva in reservas)
            {
                reservasList.Add(reserva);
                reservasFiltradas.Add(reserva);
            }



            foreach (var alojamiento in alojamientosList)
            {
                foreach (var reservado in reservasList)
                {
                    if (alojamiento.id == reservado.id_alojamiento.id)
                    {
                        reservasFiltradas.Add(reservado);
                        alojamientosFiltrados.Remove(alojamiento);
                    }
                }
            }

            if (reservasFiltradas != null)
            {

                foreach (var reservado in reservasList)
                {
                    if (fDesde >= reservado.fDesde && fHasta <= reservado.fHasta)
                    {
                        //X ------------------- ENTRE FECHAS
                        reservasFiltradas.Remove(reservado);
                    }
                    if (fHasta >= reservado.fDesde && fHasta <= reservado.fHasta)
                    {
                        //X -------------------COMIENZO y ENTRE FECHAS
                        reservasFiltradas.Remove(reservado);
                    }
                    if (fDesde <= reservado.fDesde && fDesde >= reservado.fDesde && fHasta <= reservado.fHasta && fDesde >= reservado.fDesde)
                    {
                        //COMIENTO ANTERIOS y ENTRE FECHAS y FIN DESPUES
                        reservasFiltradas.Remove(reservado);
                    }
                    if (fDesde >= reservado.fDesde && fDesde <= reservado.fHasta)
                    {
                        //ENTRE FECHAS y FIN
                        reservasFiltradas.Remove(reservado);
                    }
                }

            }

            foreach (AgenciaFinal.Models.Alojamiento alojamiento in alojamientosFiltrados)
            {
         
                if(string.Equals(ciudad, alojamiento.ciudad, StringComparison.OrdinalIgnoreCase)){
                    resultadoDeBusqueda.Add(alojamiento);
                }

            }


            foreach (AgenciaFinal.Models.Reserva reservado in reservasFiltradas)
            {
                resultadoDeBusqueda.Add(reservado.id_alojamiento);
            }

            Global.alojamientosFiltrados = resultadoDeBusqueda;

            return RedirectToAction("ResultadoBusqueda", "Usuarios");
        }


        public async Task<IActionResult> ResultadoBusqueda()
        {

            return View(Global.alojamientosFiltrados);
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
            var passViejo = Request.Form["passViejo"];
            var passNuevo1 = Request.Form["passNuevo1"];
            var passNuevo2 = Request.Form["passNuevo2"];

            if (ModelState.IsValid)
            {
                try
                {
                    if (usuario.password == passViejo.ToString())
                    {
                        if (passNuevo1.ToString() == passNuevo2.ToString())
                        {
                            usuario.password = passNuevo1;

                            Global.nombre = usuario.nombre;
                            Global.password = usuario.password;

                            _context.Update(usuario);
                            await _context.SaveChangesAsync();

                            TempData["guardado"] = "Usuario Actualizado";


                            return RedirectToAction("MisDatos", "Usuarios");
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
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
        public async Task<IActionResult> Reservar(Alojamiento alojamiento)
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
        public async Task<IActionResult> Edit(int? id)
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



        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                    TempData["guardado"] = "Usuario Actualizado";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.id))
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
            return View(usuario);
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
