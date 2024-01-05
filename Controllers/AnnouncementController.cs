using ASAG_ILIK_nvOM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
/*
namespace ASAG_ILIK_nvOM.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Announcements.ToListAsync());
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,PublishDate,IsActive,PublishedByUserId,AcceptedByUserId")] AnnouncementModel announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Announcements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Announcements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnouncementId,Title,Description,Price,PublishDate,IsActive,PublishedByUserId,AcceptedByUserId")] AnnouncementModel announcement)
        {
            if (id != announcement.AnnouncementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(announcement.AnnouncementId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Announcements.FindAsync(id);
            _context.Announcements.Remove(advertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Announcements.Any(e => e.AnnouncementId == id);
        }
    }

}
*/