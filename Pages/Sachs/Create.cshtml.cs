using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Sachs
{
    public class CreateModel : PageModel
    {
        private readonly DTODBContext _context;

        public CreateModel(DTODBContext context)
        {
            _context = context;
        }
        public IList<Theloaisach> Theloaisach { get; set; } = default!;

        public string errorMessage { get; set; } = "";

        


        public async Task<IActionResult> OnGetAsync()
        {
            Sach = new Sach();
            Sach.Ngaynhap = DateTime.Today;
            if (_context.Theloaisach != null)
            {
                Theloaisach = await _context.Theloaisach.ToListAsync();
            }
            return Page();
        }

        [BindProperty]
        public Sach Sach { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

          if(_context.Namxuatban != null)
            {
                var namxuatban = await _context.Namxuatban.ToListAsync();
                if (namxuatban.Count > 0)
                {
                    if (  DateTime.Today.Year - Sach.NamXb >= namxuatban[0].Namxuatbang)
                    {
                        errorMessage = "Sách quá hạn quy định";
                        return RedirectToPage("./Create");
                    }    
                    
                }
            }    

            _context.Sach.Add(Sach);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
