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

namespace QLTV_TKPM.Pages.Theloaisachs
{
    public class EditModel : PageModel
    {
        private readonly DTODBContext _context;

        public EditModel(DTODBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Theloaisach Theloaisach { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Theloaisach == null)
            {
                return NotFound();
            }

            var theloaisach =  await _context.Theloaisach.FirstOrDefaultAsync(m => m.Id == id);
            if (theloaisach == null)
            {
                return NotFound();
            }
            Theloaisach = theloaisach;
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

            _context.Attach(Theloaisach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheloaisachExists(Theloaisach.Id))
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

        private bool TheloaisachExists(int id)
        {
          return _context.Theloaisach.Any(e => e.Id == id);
        }
    }
}
