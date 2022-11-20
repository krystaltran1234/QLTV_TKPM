using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Theloaisachs
{
    public class DeleteModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public DeleteModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Theloaisach Theloaisach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Theloaisach == null)
            {
                return NotFound();
            }

            var theloaisach = await _context.Theloaisach.FirstOrDefaultAsync(m => m.Id == id);

            if (theloaisach == null)
            {
                return NotFound();
            }
            else 
            {
                Theloaisach = theloaisach;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Theloaisach == null)
            {
                return NotFound();
            }
            var theloaisach = await _context.Theloaisach.FindAsync(id);

            if (theloaisach != null)
            {
                Theloaisach = theloaisach;
                _context.Theloaisach.Remove(Theloaisach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
