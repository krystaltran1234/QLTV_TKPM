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
    public class IndexModel : PageModel
    {
        private readonly DTODBContext _context;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public IndexModel(DTODBContext context)
        {
            _context = context;
        }

        public IList<Theloaisach> Theloaisach { get;set; } = default!;

        public async Task OnGetAsync()
        {

            var theloaisaches = from m in _context.Theloaisach
                        select m;
            if (_context.Theloaisach != null)
            {
                Theloaisach = await _context.Theloaisach.ToListAsync();
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                theloaisaches = theloaisaches.Where(s => s.Tentheloaisach.Contains(SearchString));
                Theloaisach = await theloaisaches.ToListAsync();
            }

        }
    }
}
