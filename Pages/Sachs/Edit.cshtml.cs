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
    public class EditModel : PageModel
    {
        private readonly DTODBContext _context;

        public EditModel(DTODBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sach Sach { get; set; } = default!;
        public IList<Theloaisach> Theloaisach { get; set; } = default!;
        public string errorMessage { get; set; } = "";


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Theloaisach != null)
            {
                Theloaisach = await _context.Theloaisach.ToListAsync();
            }
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach =  await _context.Sach.FirstOrDefaultAsync(m => m.Id == id);
            if (sach == null)
            {
                return NotFound();
            }
            Sach = sach;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_context.Namxuatban != null)
            {
                var namxuatban = await _context.Namxuatban.ToListAsync();
                if (namxuatban.Count > 0)
                {
                    if (DateTime.Today.Year - Sach.NamXb >= namxuatban[0].Namxuatbang)
                    {
                        errorMessage = "Sách quá hạn quy định";
                        return RedirectToPage($"./Edit/");
                    }

                }
            }

            _context.Attach(Sach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SachExists(Sach.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SachExists(int id)
        {
          return _context.Sach.Any(e => e.Id == id);
        }
    }
}
