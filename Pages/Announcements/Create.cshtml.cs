using ASAG_ILIK_nvOM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ASAG_ILIK_nvOM.Pages.Announcements
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public UserModel UserModel { get; set; }

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public AnnouncementModel Announcements { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            ModelState.Remove("Password");
            ModelState.Remove("Username");

            var userId = HttpContext.Session.GetInt32("UserId");
            Announcements.PublishedByUserId = (int)userId;
            Announcements.IsActive = true;
            if (ModelState.IsValid)
            {
                await _db.Announcements.AddAsync(Announcements);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
