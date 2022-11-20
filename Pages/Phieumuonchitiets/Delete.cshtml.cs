using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Phieumuonchitiets
{
    public class DeleteModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public DeleteModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Phieumuonchitiet Phieumuonchitiet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Phieumuonchitiet == null)
            {
                return NotFound();
            }

            var phieumuonchitiet = await _context.Phieumuonchitiet.FirstOrDefaultAsync(m => m.Id == id);

            if (phieumuonchitiet == null)
            {
                return NotFound();
            }
            else 
            {
                Phieumuonchitiet = phieumuonchitiet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Phieumuonchitiet == null)
            {
                return NotFound();
            }
            var phieumuonchitiet = await _context.Phieumuonchitiet.FindAsync(id);

            if (phieumuonchitiet != null)
            {
                Phieumuonchitiet = phieumuonchitiet;
                _context.Phieumuonchitiet.Remove(Phieumuonchitiet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
