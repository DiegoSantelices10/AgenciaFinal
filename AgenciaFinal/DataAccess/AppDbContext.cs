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


        public DbSet<Libro> Libro { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Alojamiento> Alojamiento { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}

