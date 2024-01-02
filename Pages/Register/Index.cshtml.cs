// Pages/Register/Index.cshtml.cs
using ASAG_ILIK_nvOM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASAG_ILIK_nvOM.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public void OnGet()
        {
            // Sayfa yüklenirken yapýlacak iþlemler (opsiyonel)
        }
        public async Task<IActionResult> OnPost()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(UserModel);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }

        }

    }
}
