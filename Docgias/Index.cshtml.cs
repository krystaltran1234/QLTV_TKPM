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
    public class IndexModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public IndexModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }
        public List<Loaidocgia> Loaidocgia { get; set; } = default!;

        public IList<Docgia> Docgia { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Loaidocgia != null)
            {
                Loaidocgia = await _context.Loaidocgia.ToListAsync();
            }
            if (_context.Docgia != null)
            {
                Docgia = await _context.Docgia.ToListAsync();
            }
        }
    }
}
