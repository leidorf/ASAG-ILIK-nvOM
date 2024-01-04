// Pages/Announcements/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASAG_ILIK_nvOM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASAG_ILIK_nvOM.Pages.Announcements
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<AnnouncementModel> Announcements { get; set; }

        public async Task OnGet()
        {
            Announcements = await _db.Announcements.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var announcement = await _db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            _db.Announcements.Remove(announcement);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
