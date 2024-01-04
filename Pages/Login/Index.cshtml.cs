// Pages/Login/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASAG_ILIK_nvOM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ASAG_ILIK_nvOM.Pages.Login
{

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public UserModel UserModel { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult OnPost()
        {
            // Kullan�c�y� veritaban�nda kontrol et (�rne�in sadece kullan�c� ad� kontrol� yap�l�yor)
            var user = _context.Users.SingleOrDefault(u => u.Username == UserModel.Username);

            if (user != null && user.Password == UserModel.Password)
            {

                return RedirectToPage("/Home/Index");
            }

            // Giri� ba�ar�s�z, kullan�c�y� ayn� sayfaya geri y�nlendir
            return Page();
        }
    }
}
