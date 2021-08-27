using AgenciaFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaFinal.DataAccess
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {


        }


        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Alojamiento> Alojamiento { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
    }
}

