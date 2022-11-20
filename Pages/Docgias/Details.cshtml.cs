using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Docgias
{
    public class DetailsModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public DetailsModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }
        public Loaidocgia Loaidocgia { get; set; } = default!;

        public Docgia Docgia { get; set; }
        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Docgia == null)
            {
                return NotFound();
            }

            var docgia = await _context.Docgia.FirstOrDefaultAsync(m => m.Id == id);
            if (docgia == null)
            {
                return NotFound();
            }
            else 
            {
                Docgia = docgia;
                if (_context.Loaidocgia != null)
                {
                    Loaidocgia = await _context.Loaidocgia.FirstOrDefaultAsync(m => m.Id == Docgia.LoaiDocGia);
                }
            }
            return Page();
        }
    }
}
