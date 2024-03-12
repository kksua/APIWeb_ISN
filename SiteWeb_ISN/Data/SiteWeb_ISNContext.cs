using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteWeb_ISN.Models;

namespace SiteWeb_ISN.Data
{
    public class SiteWeb_ISNContext : DbContext
    {
        public SiteWeb_ISNContext (DbContextOptions<SiteWeb_ISNContext> options)
            : base(options)
        {
        }

        public DbSet<SiteWeb_ISN.Models.Album> Album { get; set; } = default!;

        public DbSet<SiteWeb_ISN.Models.Chanson>? Chanson { get; set; }

        public DbSet<SiteWeb_ISN.Models.Chanteur>? Chanteur { get; set; }

        public DbSet<SiteWeb_ISN.Models.Ouvrage>? Ouvrage { get; set; }

        public DbSet<SiteWeb_ISN.Models.Utilisateur>? Utilisateur { get; set; }
    }
}
