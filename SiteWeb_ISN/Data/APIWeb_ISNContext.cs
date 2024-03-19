using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIWeb_ISN.Models;

namespace APIWeb_ISN.Data
{
    public class APIWeb_ISNContext : DbContext
    {
        public APIWeb_ISNContext (DbContextOptions<APIWeb_ISNContext> options)
            : base(options)
        {
        }

        public DbSet<APIWeb_ISN.Models.Album> Album { get; set; } = default!;

        public DbSet<APIWeb_ISN.Models.Chanson>? Chanson { get; set; }

        public DbSet<APIWeb_ISN.Models.Chanteur>? Chanteur { get; set; }

        public DbSet<APIWeb_ISN.Models.Ouvrage>? Ouvrage { get; set; }

        public DbSet<APIWeb_ISN.Models.Utilisateur>? Utilisateur { get; set; }
    }
}
