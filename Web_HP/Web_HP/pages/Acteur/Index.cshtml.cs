using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APIWeb_ISN.Models;
using Web_HP.Data;

namespace Web_HP.pages.Acteur
{
    public class IndexModel : PageModel
    {
        private readonly Web_HP.Data.Web_HPContext _context;

        public IndexModel(Web_HP.Data.Web_HPContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Album != null)
            {
                Album = await _context.Album.ToListAsync();
            }
        }
    }
}
