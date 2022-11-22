using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Sachs
{
    public class IndexModel : PageModel
    {
        private readonly DTODBContext _context;

        public IndexModel(DTODBContext context)
        {
            _context = context;
        }
        public IList<Theloaisach> Theloaisach { get; set; } = default!;

        public IList<Sach> Sach { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var sachs = from m in _context.Sach
                        select m;
            if (_context.Theloaisach != null)
            {
                Theloaisach = await _context.Theloaisach.ToListAsync();

            }
            if (_context.Sach != null)
            {

                Sach = await _context.Sach.ToListAsync();
            }
           
            if (!string.IsNullOrEmpty(SearchString))
            {
                sachs = sachs.Where(s => s.Tensach.Contains(SearchString));
                Sach = await sachs.ToListAsync();
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
