using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIWeb_ISN.Models;

namespace Web_HP.Data
{
    public class Web_HPContext : DbContext
    {
        public Web_HPContext (DbContextOptions<Web_HPContext> options)
            : base(options)
        {
        }

   

        public DbSet<Web_HP.Models.Acteur>? Acteur { get; set; }


    }
}
