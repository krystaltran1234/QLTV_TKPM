using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Thoihanthes
{
    public class DetailsModel : PageModel
    {
        private readonly DTODBContext _context;

        public DetailsModel(DTODBContext context)
        {
            _context = context;
        }

      public Thoihanthe Thoihanthe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Thoihanthe == null)
            {
                return NotFound();
            }

            var thoihanthe = await _context.Thoihanthe.FirstOrDefaultAsync(m => m.Id == id);
            if (thoihanthe == null)
            {
                return NotFound();
            }
            else 
            {
                Thoihanthe = thoihanthe;
            }
            return Page();
        }
    }
}
