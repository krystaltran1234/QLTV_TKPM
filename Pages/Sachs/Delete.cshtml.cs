using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Sachs
{
    public class DeleteModel : PageModel
    {
        private readonly DTODBContext _context;

        public DeleteModel(DTODBContext context)
        {
            _context = context;
        }
        public Theloaisach Theloaisach { get; set; } = default!;
        
            

            [BindProperty]
      public Sach Sach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FirstOrDefaultAsync(m => m.Id == id);

            if (sach == null)
            {
                return NotFound();
            }
            else 
            {
                Sach = sach;
                if (_context.Theloaisach != null)
                {
                    Theloaisach = await _context.Theloaisach.FirstOrDefaultAsync(m => m.Id == Sach.Theloaisach);
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }
            var sach = await _context.Sach.FindAsync(id);

            if (sach != null)
            {
                Sach = sach;
                _context.Sach.Remove(Sach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
