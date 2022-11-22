using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Namxuatbans
{
    public class DeleteModel : PageModel
    {
        private readonly DTODBContext _context;

        public DeleteModel(DTODBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Namxuatban Namxuatban { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Namxuatban == null)
            {
                return NotFound();
            }

            var namxuatban = await _context.Namxuatban.FirstOrDefaultAsync(m => m.Id == id);

            if (namxuatban == null)
            {
                return NotFound();
            }
            else 
            {
                Namxuatban = namxuatban;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Namxuatban == null)
            {
                return NotFound();
            }
            var namxuatban = await _context.Namxuatban.FindAsync(id);

            if (namxuatban != null)
            {
                Namxuatban = namxuatban;
                _context.Namxuatban.Remove(Namxuatban);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
