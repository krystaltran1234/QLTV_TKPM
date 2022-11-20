using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Loaidocgias
{
    public class DeleteModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public DeleteModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Loaidocgia Loaidocgia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Loaidocgia == null)
            {
                return NotFound();
            }

            var loaidocgia = await _context.Loaidocgia.FirstOrDefaultAsync(m => m.Id == id);

            if (loaidocgia == null)
            {
                return NotFound();
            }
            else 
            {
                Loaidocgia = loaidocgia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Loaidocgia == null)
            {
                return NotFound();
            }
            var loaidocgia = await _context.Loaidocgia.FindAsync(id);

            if (loaidocgia != null)
            {
                Loaidocgia = loaidocgia;
                _context.Loaidocgia.Remove(Loaidocgia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
