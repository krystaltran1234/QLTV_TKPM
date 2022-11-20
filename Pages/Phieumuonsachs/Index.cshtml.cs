using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Phieumuonsachs
{
    public class IndexModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public IndexModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        public IList<Phieumuonsach> Phieumuonsach { get;set; } = default!;

        public IList<Docgia> Docgia { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if(_context.Docgia != null)
            {
                Docgia = await _context.Docgia.ToListAsync();
            }    
            if (_context.Phieumuonsach != null)
            {
                Phieumuonsach = await _context.Phieumuonsach.ToListAsync();
            }
        }
       
    }
}
