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
    public class IndexModel : PageModel
    {
        private readonly DTODBContext _context;

        public IndexModel(DTODBContext context)
        {
            _context = context;
        }

        public IList<Thoihanthe> Thoihanthe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Thoihanthe != null)
            {
                Thoihanthe = await _context.Thoihanthe.ToListAsync();
            }
        }
    }
}
