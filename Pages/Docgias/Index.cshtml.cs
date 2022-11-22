using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;
using BLL;

namespace QLTV_TKPM.Pages.Docgias
{
    public class IndexModel : PageModel
    {
        private readonly DTODBContext _context;
        public XLDocgia xLDocgia { get; set; }
        public XLLoaidocgia xLLoaidocgia { get; set; }

        public IndexModel(DTODBContext context)
        {
            _context = context;
            xLDocgia = new XLDocgia(context);
            xLLoaidocgia = new XLLoaidocgia(context);
        }
        public IList<Loaidocgia> Loaidocgia { get; set; }

        public IList<Docgia> Docgia { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var docgias = from m in _context.Docgia
                        select m;
            if (_context.Loaidocgia != null)
            {
                Loaidocgia = await xLLoaidocgia.GetAllAsync();
            }
            if (_context.Docgia != null)
            {
                Docgia = await xLDocgia.GetAllAsync();
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                Docgia = await xLDocgia.GetSearchAsync(SearchString);
            }
        }
    }
}
