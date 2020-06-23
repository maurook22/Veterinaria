using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pericles.Models;

namespace Pericles.Context
{
    public class PericlesContext : DbContext
    {
        
        public DbSet<Duenio> duenios { get; set; }
        public DbSet<Consulta> consultas { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<Veterinario> veterinarios { get; set; }

        public PericlesContext(DbContextOptions<PericlesContext> options) : base(options)
        {

        }

    }
}
