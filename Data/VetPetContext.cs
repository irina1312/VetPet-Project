using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetPet.Models;

namespace VetPet.Data
{
    public class VetPetContext : DbContext
    {
        public VetPetContext (DbContextOptions<VetPetContext> options)
            : base(options)
        {
        }

        public DbSet<VetPet.Models.Programare> Programare { get; set; }

        public DbSet<VetPet.Models.Review> Review { get; set; }
    }
}
