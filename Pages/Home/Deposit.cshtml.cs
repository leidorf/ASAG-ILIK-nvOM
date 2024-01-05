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
            // Kullan�c�n�n benzersiz kimli�ini al�n
            var userId = HttpContext.Session.GetInt32("UserId");
            int? currentBalance = HttpContext.Session.GetInt32("Balance");
            // Kullan�c�n�n mevcut bakiyesini al�n
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                // Yeni bakiyeyi ekleyin
                user.Balance += Amount;
                int newBalance = (int)user.Balance;

                // Veritaban�n� g�ncelleyin
                HttpContext.Session.SetInt32("Balance", newBalance);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                // Ba�ar� durumunda ana sayfaya y�nlendirin
                return RedirectToPage("/Home/Index");
            }

            // E�er i�lem ba�ar�s�z olursa veya ge�ersizse, ayn� sayfaya geri d�n�n
            return Page();
        }
    }
}
