using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASAG_ILIK_nvOM.Pages.Home
{
    public class DepositModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DepositModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public decimal Amount { get; set; }

        public async Task<IActionResult> OnPost()
        {
            // Kullanýcýnýn benzersiz kimliðini alýn
            var userId = HttpContext.Session.GetInt32("UserId");
            int? currentBalance = HttpContext.Session.GetInt32("Balance");
            // Kullanýcýnýn mevcut bakiyesini alýn
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                // Yeni bakiyeyi ekleyin
                user.Balance += Amount;
                int newBalance = (int)user.Balance;

                // Veritabanýný güncelleyin
                HttpContext.Session.SetInt32("Balance", newBalance);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                // Baþarý durumunda ana sayfaya yönlendirin
                return RedirectToPage("/Home/Index");
            }

            // Eðer iþlem baþarýsýz olursa veya geçersizse, ayný sayfaya geri dönün
            return Page();
        }
    }
}
