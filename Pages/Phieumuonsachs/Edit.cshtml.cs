using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Data;
using Entity;

namespace QLTV_TKPM.Pages.Phieumuonsachs
{
    public class EditModel : PageModel
    {
        private readonly DTODBContext _context;

        public EditModel(DTODBContext context)
        {
            _context = context;
        }

        public int Soluongsachmuon { get; set; }
        

              


        [BindProperty]
        public IList<Phieumuonchitiet> Phieumuonchitiets { get; set; }

        [BindProperty]
        public Phieumuonsach phieumuonsaches { get; set; }



        public IList<Docgia> docgias { get; set; }

        
        public IList<Sach> sachs { get; set; }

        public string errorMessage { get; set; } = "";



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var Soluongsachmuons = await _context.Soluongsachmuon.ToListAsync();


            if (_context.Soluongsachmuon != null)
            {
                Soluongsachmuon = Soluongsachmuons[0].Soluongsachmuontoida;
            }
            
            
            if (_context.Sach != null)
            {
                sachs = await _context.Sach.ToListAsync();
            }
            if (_context.Docgia != null)
            {
                docgias = await _context.Docgia.ToListAsync();
            }
            
            if (id == null || _context.Phieumuonchitiet == null)
            {
                return NotFound();
            }
            if(_context.Phieumuonsach != null)
            {
                phieumuonsaches = await _context.Phieumuonsach.FirstOrDefaultAsync(m => m.Id == id);
                if(phieumuonsaches != null && _context.Phieumuonchitiet != null)
                {
                    Phieumuonchitiets = await _context.Phieumuonchitiet.Where(m => m.Maphieumuonsach == phieumuonsaches.Id).ToListAsync();
                }    
            } 
                
            //var phieumuonsach = await _context.Phieumuonsach.FirstOrDefaultAsync(m => m.Id == id);
            //Madocgia = phieumuonsach.MaDocGia.ToString() + "-";
            //Ngaymuon = phieumuonsach.NgayMuon;
            //Maphieumuonsach = phieumuonsach.Id;
            //int maphieumuonsach = phieumuonsach.Id;            
            
            //if (phieumuonsach != null)
            //{
            //    Masach = new List<string>();
            //    var phieumuonchitiet = await _context.Phieumuonchitiet.Where(m => m.Maphieumuonsach == maphieumuonsach).ToListAsync();
            //    for (int i=0; i<phieumuonchitiet.Count; i++)
            //    {

            //        Masach.Add(phieumuonchitiet[i].MaSach.ToString() + "-");
            //        Maphieumuonchitiet.Add(phieumuonchitiet[i].Id);
            //    }    
                
            //}
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            
            if (!checkMasach())
            {
                
                return RedirectToPage($"./Index/{phieumuonsaches.Id}");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }

            if (_context.Docgia != null)
            {
                var docgias = await _context.Docgia.FirstOrDefaultAsync(m => m.Id == phieumuonsaches.MaDocGia);
                var Ngaymuon = phieumuonsaches.NgayMuon;
                if (docgias.Ngaylapthe.Year - Ngaymuon.Year > 0)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    if (_context.Thoihanthe != null)
                    {
                        var thoihanthe = await _context.Thoihanthe.ToListAsync();
                        if (thoihanthe.Count > 0)
                        {
                            if (docgias.Ngaylapthe.Month - Ngaymuon.Month > thoihanthe[0].Sothang)
                            {
                                errorMessage = "Thẻ đã quá hạn.";
                                return Page();
                            }

                        }
                    }

                }

            }
            _context.Attach(phieumuonsaches).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            List<Sach> _sach = new List<Sach>();
            try
            {
                for(int i = 0; i<Phieumuonchitiets.Count;i++)
                {
                    var _sach1 = new Sach
                    {
                        Id = Phieumuonchitiets[i].MaSach,
                        Tinhtrang = "Đã Mượn"
                    };
                    _context.Attach(_sach1);
                    _context.Entry(_sach1).Property(r => r.Tinhtrang).IsModified = true;
                    await _context.SaveChangesAsync();
                }
                
                
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieumuonchitietExists(phieumuonsaches.Id))
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

        public bool checkMasach()
        {
            int i = 0;
            foreach (var item in Phieumuonchitiets)
            {
                if (item != null)
                {
                    i++;
                }
            }
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        private bool PhieumuonchitietExists(int id)
        {
          return _context.Phieumuonchitiet.Any(e => e.Id == id);
        }
    }
}
