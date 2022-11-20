﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Pages.Namxuatbans
{
    public class EditModel : PageModel
    {
        private readonly QLTV_TKPM.Data.QLTV_TKPMContext _context;

        public EditModel(QLTV_TKPM.Data.QLTV_TKPMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Namxuatban Namxuatban { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Namxuatban == null)
            {
                return NotFound();
            }

            var namxuatban =  await _context.Namxuatban.FirstOrDefaultAsync(m => m.Id == id);
            if (namxuatban == null)
            {
                return NotFound();
            }
            Namxuatban = namxuatban;
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

            _context.Attach(Namxuatban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NamxuatbanExists(Namxuatban.Id))
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

        private bool NamxuatbanExists(int id)
        {
          return _context.Namxuatban.Any(e => e.Id == id);
        }
    }
}
