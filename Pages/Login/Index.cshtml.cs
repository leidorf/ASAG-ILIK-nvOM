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
            // Kullanýcýyý veritabanýnda kontrol et (örneðin sadece kullanýcý adý kontrolü yapýlýyor)
            var user = _context.Users.SingleOrDefault(u => u.Username == UserModel.Username);

            if (user != null && user.Password == UserModel.Password)
            {

                return RedirectToPage("/Home/Index");
            }

            // Giriþ baþarýsýz, kullanýcýyý ayný sayfaya geri yönlendir
            return Page();
        }
    }
}
