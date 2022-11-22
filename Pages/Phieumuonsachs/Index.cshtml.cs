using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Phieumuonsachs
{
    public class IndexModel : PageModel
    {
        private readonly DTODBContext _context;

        public IndexModel(DTODBContext context)
        {
            _context = context;
        }

        public IList<Phieumuonsach> Phieumuonsach { get;set; } = default!;

        public IList<Docgia> Docgia { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var docgias = from m in _context.Docgia
                        select m;
            if (_context.Docgia != null)
            {
                Docgia = await _context.Docgia.ToListAsync();
            }    
            if (_context.Phieumuonsach != null)
            {
                Phieumuonsach = await _context.Phieumuonsach.ToListAsync();
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                docgias = docgias.Where(s => s.Hoten.Contains(SearchString));
                Docgia = await docgias.ToListAsync();
            }
        }
       
    }
}
