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
//using BLL;

namespace QLTV_TKPM.Pages.Sachs
{
    public class CreateModel : PageModel
    {
        private readonly DTODBContext _context;
        
        //private XLTheloaisach xLTheloaisach { get; set; }

        //private XLSach xLSach { get; set; }

        //private XLNamxuatban xLNamxuatban { get; set; }

        public CreateModel(DTODBContext context)
        {
            _context = context;
            //xLSach = new XLSach(context);
            //xLTheloaisach = new XLTheloaisach(context);
            //xLNamxuatban = new XLNamxuatban(context);
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
                //Nếu có Theloaisach khai báo private XLTheloaisach xLTheloaisach { get; set; } như dòng 19 + dòng 29 + 11
                //Tương tự cho các Table khác
                //Đóng comment dòng 45 mở dòng 49
                //Theloaisach = await xLTheloaisach.GetAllAsync();
                //Quy đổi: ToListAsync == GetAllAsync
                //FirstOrDefaultAsync = GetIdAsync
                //FindAsync = FindAsync
                //_context.Sach.Remove(Sach); +  await _context.SaveChangesAsync(); = 
                //search = GetSearchAsync
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
                //var namxuatban = await xLNamxuatban.GetAllAsync();
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
            //Quy đổi dòng 81 + 82 = 84
            //xLSach.SaveChangesAsync(Sach);

            return RedirectToPage("./Index");
        }
    }
}
