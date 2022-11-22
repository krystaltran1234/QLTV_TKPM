using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Thoihanthes
{
    public class CreateModel : PageModel
    {
        private readonly DTODBContext _context;

        public CreateModel(DTODBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Thoihanthe Thoihanthe { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Thoihanthe.Add(Thoihanthe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
