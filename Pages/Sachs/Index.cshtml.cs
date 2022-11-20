using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Sachs
{
    public class IndexModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public IndexModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }
        public IList<Theloaisach> Theloaisach { get; set; } = default!;

        public IList<Sach> Sach { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Theloaisach != null)
            {
                Theloaisach = await _context.Theloaisach.ToListAsync();
                
            }
            if (_context.Sach != null)
            {
                Sach = await _context.Sach.ToListAsync();
            }
        }
        public async Task Search(string searchString)
        {
            
            if (!String.IsNullOrEmpty(searchString))
            {
                Sach = await _context.Sach.Where(s => s.Tensach.Contains(searchString)).ToListAsync();

            }

            Sach = await _context.Sach.ToListAsync();
        }
    }
}
