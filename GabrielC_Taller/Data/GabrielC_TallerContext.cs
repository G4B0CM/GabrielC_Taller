using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GabrielC_Taller.Models;

namespace GabrielC_Taller.Data
{
    public class GabrielC_TallerContext : DbContext
    {
        public GabrielC_TallerContext (DbContextOptions<GabrielC_TallerContext> options)
            : base(options)
        {
        }

        public DbSet<GabrielC_Taller.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<GabrielC_Taller.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<GabrielC_Taller.Models.Jugador> Jugador { get; set; } = default!;
    }
}
