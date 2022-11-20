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
    public class CreateModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public CreateModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Docgia Docgia { get; set; }

        public IList<Loaidocgia> Loaidocgia { get; set; } = default!;

        public Tuoidocgia tuoidocgia { get; set; }
        public string errorMessage { get; set; } = "";

        public async Task<IActionResult> OnGetAsync()
        {
            Docgia = new Docgia();
            Docgia.Ngaysinh = DateTime.Today;
            Docgia.Ngaylapthe = DateTime.Today;
            
            if (_context.Loaidocgia != null)
            {
                Loaidocgia = await _context.Loaidocgia.ToListAsync();
            }
               
            return Page();
        }
        

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                    int tuoihientai = year.Year - DateTime.Today.Year;
                    if(tuoihientai < tuoidocgias[0].TuoiMin || tuoihientai > tuoidocgias[0].TuoiMax)
                    {
                        errorMessage = "Tuổi của bạn quá tuổi quy định";
                        return Page();
                    }    
                }

            }

            _context.Docgia.Add(Docgia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
