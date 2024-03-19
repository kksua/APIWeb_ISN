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

        public DbSet<APIWeb_ISN.Models.Acteur>? Acteur { get; set; }

        public DbSet<APIWeb_ISN.Models.Directeurs>? Directeurs { get; set; }

        public DbSet<APIWeb_ISN.Models.Media>? Media { get; set; }

        public DbSet<APIWeb_ISN.Models.Movies>? Movies { get; set; }

        public DbSet<APIWeb_ISN.Models.Series>? Series { get; set; }

        public DbSet<APIWeb_ISN.Models.FavoriteMedia>? FavoriteMedia { get; set; }
    }
}
