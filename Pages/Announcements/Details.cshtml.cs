using ASAG_ILIK_nvOM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; // HttpContext.Session için ekledik

namespace ASAG_ILIK_nvOM.Pages.Announcements
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly AnnouncementService _announcementService;

        public DetailsModel(ApplicationDbContext context, AnnouncementService announcementService)
        {
            _context = context;
            _announcementService = announcementService;
        }

        [BindProperty]
        public AnnouncementModel Announcement { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement = _context.Announcements.FirstOrDefault(m => m.AnnouncementId == id);

            if (Announcement == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostComplete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId != null)
            {
                _announcementService.CompleteAnnouncement(id, (int)userId);
                return RedirectToPage("./Index");
            }

            // Kullanýcý oturumu açýk deðilse uygun bir iþlem yap veya hata mesajýný göster
            return RedirectToPage("/Account/Login");
        }

        public IActionResult OnPostAccept(int id)
        {
            Announcement = _context.Announcements.Find(id);
            var userId = HttpContext.Session.GetInt32("UserId");

            if (Announcement == null)
            {
                return NotFound();
            }

            Announcement.AcceptedByUserId = (int)userId;
            Announcement.IsActive = false;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
