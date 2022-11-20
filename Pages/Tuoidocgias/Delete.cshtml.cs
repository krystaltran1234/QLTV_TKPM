using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Tuoidocgias
{
    public class DeleteModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public DeleteModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tuoidocgia Tuoidocgia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tuoidocgia == null)
            {
                return NotFound();
            }

            var tuoidocgia = await _context.Tuoidocgia.FirstOrDefaultAsync(m => m.Id == id);

            if (tuoidocgia == null)
            {
                return NotFound();
            }
            else 
            {
                Tuoidocgia = tuoidocgia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tuoidocgia == null)
            {
                return NotFound();
            }
            var tuoidocgia = await _context.Tuoidocgia.FindAsync(id);

            if (tuoidocgia != null)
            {
                Tuoidocgia = tuoidocgia;
                _context.Tuoidocgia.Remove(Tuoidocgia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
