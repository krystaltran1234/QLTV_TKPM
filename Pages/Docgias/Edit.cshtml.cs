using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Docgias
{
    public class EditModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public EditModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }
        public IList<Loaidocgia> Loaidocgia { get; set; } = default!;

        [BindProperty]
        public Docgia Docgia { get; set; } = default!;

        public string errorMessage { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id)

        {
            
            if (_context.Loaidocgia != null)
            {
                Loaidocgia = await _context.Loaidocgia.ToListAsync();
            }
            if (id == null || _context.Docgia == null)
            {
                return NotFound();
            }

            var docgia =  await _context.Docgia.FirstOrDefaultAsync(m => m.Id == id);
            if (docgia == null)
            {
                return NotFound();
            }
            Docgia = docgia;
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
            if (_context.Tuoidocgia != null)
            {
                var tuoidocgias = await _context.Tuoidocgia.ToListAsync();
                if (tuoidocgias.Count > 0)
                {
                    int tuoiMin = tuoidocgias[0].TuoiMin;
                    int tuoiMax = tuoidocgias[0].TuoiMax;
                    DateTime year = Docgia.Ngaysinh;
                    int tuoihientai = year.Year - DateTime.Today.Year ;
                    if (tuoihientai < tuoidocgias[0].TuoiMin || tuoihientai > tuoidocgias[0].TuoiMax)
                    {
                        errorMessage = "Tuổi của bạn quá tuổi quy định";
                        return Page();
                    }
                }

            }

            _context.Attach(Docgia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocgiaExists(Docgia.Id))
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

        private bool DocgiaExists(int id)
        {
          return _context.Docgia.Any(e => e.Id == id);
        }
    }
}
