using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Tuoidocgias
{
    public class DetailsModel : PageModel
    {
        private readonly DTODBContext _context;

        public DetailsModel(DTODBContext context)
        {
            _context = context;
        }

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
    }
}
