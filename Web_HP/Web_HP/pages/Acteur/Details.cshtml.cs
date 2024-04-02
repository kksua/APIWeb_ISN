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
    public class DetailsModel : PageModel
    {
        private readonly Web_HP.Data.Web_HPContext _context;

        public DetailsModel(Web_HP.Data.Web_HPContext context)
        {
            _context = context;
        }

      public Album Album { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FirstOrDefaultAsync(m => m.IdAlbum == id);
            if (album == null)
            {
                return NotFound();
            }
            else 
            {
                Album = album;
            }
            return Page();
        }
    }
}
