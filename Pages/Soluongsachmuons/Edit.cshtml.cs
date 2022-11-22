using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Soluongsachmuons
{
    public class EditModel : PageModel
    {
        private readonly DTODBContext _context;

        public EditModel(DTODBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Soluongsachmuon Soluongsachmuon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Soluongsachmuon == null)
            {
                return NotFound();
            }

            var soluongsachmuon =  await _context.Soluongsachmuon.FirstOrDefaultAsync(m => m.Id == id);
            if (soluongsachmuon == null)
            {
                return NotFound();
            }
            Soluongsachmuon = soluongsachmuon;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Soluongsachmuon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoluongsachmuonExists(Soluongsachmuon.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoluongsachmuonExists(int id)
        {
          return _context.Soluongsachmuon.Any(e => e.Id == id);
        }
    }
}
