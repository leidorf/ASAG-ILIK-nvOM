// Pages/Login/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASAG_ILIK_nvOM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;

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

        public IActionResult OnPost()
        {
            // Kullan�c�y� veritaban�nda kontrol et (�rne�in sadece kullan�c� ad� kontrol� yap�l�yor)
            var user = _context.Users.SingleOrDefault(u => u.Username == UserModel.Username);

            if (user != null && user.Password == UserModel.Password)
            {
                string userName = user.Username;
                int userId = user.UserId;
                decimal balance = user.Balance;
                bool isEmployer = user.IsEmployer;

                HttpContext.Session.SetInt32("UserId", userId);
                HttpContext.Session.SetString("IsEmployer", isEmployer.ToString());
                HttpContext.Session.SetString("Username", userName);
                HttpContext.Session.SetInt32("Balance", (int)balance);
                
                return RedirectToPage("/Home/Index");
            }

            // Giri� ba�ar�s�z, kullan�c�y� ayn� sayfaya geri y�nlendir
            return Page();
        }
    }
}
