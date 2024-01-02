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
            // Ýlanlarý veritabanýndan çekerek Model.Announcements üzerine atama yapabilirsiniz
            Announcements = await _context.Announcements.ToListAsync();
        }

        // Model üzerinde kullanýlacak property'leri tanýmlayabilirsiniz
        public List<AnnouncementModel> Announcements { get; set; }
    }
}
