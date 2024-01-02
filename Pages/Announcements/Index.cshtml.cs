// Pages/Announcements/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASAG_ILIK_nvOM.Models;

namespace ASAG_ILIK_nvOM.Pages.Announcements
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // �lanlar� veritaban�ndan �ekerek Model.Announcements �zerine atama yapabilirsiniz
            Announcements = await _context.Announcements.ToListAsync();
        }

        // Model �zerinde kullan�lacak property'leri tan�mlayabilirsiniz
        public List<AnnouncementModel> Announcements { get; set; }
    }
}
