using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity;
using QLTV_TKPM.Data;
using DTO;
using BLL;

namespace QLTV_TKPM.Pages.Docgias
{
    public class CreateModel : PageModel
    {
        private readonly DTODBContext  _context;
        public XLLoaidocgia _xLLoaidocgia { get; set; }
        public XLDocgia xLDocgia { get; set; }
        public CreateModel(DTODBContext context)
        {
            _context = context;
            _xLLoaidocgia = new XLLoaidocgia(context);
            xLDocgia = new XLDocgia(_context);
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
            Loaidocgia = await _xLLoaidocgia.GetAllAsync();          
               
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
                    DateTime year = Docgia.Ngaysinh;
                    int tuoihientai = year.Year - DateTime.Today.Year;
                    if (tuoihientai < tuoidocgias[0].TuoiMin || tuoihientai > tuoidocgias[0].TuoiMax)
                    {
                        errorMessage = "Tuổi của bạn quá tuổi quy định";
                        return Page();
                    }
                }

            }

            await xLDocgia.SaveChangesAsync(Docgia);

            return RedirectToPage("./Index");
        }
    }
}
