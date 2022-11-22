using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Theloaisachs
{
    public class DetailsModel : PageModel
    {
        private readonly DTODBContext _context;

        public DetailsModel(DTODBContext context)
        {
            _context = context;
        }

      public Theloaisach Theloaisach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Theloaisach == null)
            {
                return NotFound();
            }

            var theloaisach = await _context.Theloaisach.FirstOrDefaultAsync(m => m.Id == id);
            if (theloaisach == null)
            {
                return NotFound();
            }
            else 
            {
                Theloaisach = theloaisach;
            }
            return Page();
        }
    }
}
