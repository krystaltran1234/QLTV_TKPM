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
    public class DeleteModel : PageModel
    {
        private readonly DTODBContext _context;
        public XLDocgia xLDocgia { get; set; }
        public XLLoaidocgia xLLoaidocgia { get; set; }

        public DeleteModel(DTODBContext context)
        {
            _context = context;
            xLDocgia = new XLDocgia(context);
            xLLoaidocgia = new XLLoaidocgia(context);
        }

        [BindProperty]
        public Docgia Docgia { get; set; }

        public Loaidocgia Loaidocgia { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            if ( _context.Docgia == null)
            {
                return NotFound();
            }

            var docgia = await xLDocgia.GetIdAsync(id);

            if (docgia == null)
            {
                return NotFound();
            }
            else 
            {
                Docgia = docgia;
                if (_context.Loaidocgia != null)
                {
                    Loaidocgia = await xLLoaidocgia.GetIdAsync(Docgia.LoaiDocGia);
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Docgia == null)
            {
                return NotFound();
            }
            var docgia = await xLDocgia.FindAsync(id.Value);

            if (docgia != null)
            {
                Docgia = docgia;
                await xLDocgia.PostDeleteAsync(docgia);
            }

            return RedirectToPage("./Index");
        }
    }
}
