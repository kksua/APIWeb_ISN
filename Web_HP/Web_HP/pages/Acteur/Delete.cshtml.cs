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
    public class DeleteModel : PageModel
    {
        private readonly Web_HP.Data.Web_HPContext _context;

        public DeleteModel(Web_HP.Data.Web_HPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }
            var album = await _context.Album.FindAsync(id);

            if (album != null)
            {
                Album = album;
                _context.Album.Remove(Album);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
