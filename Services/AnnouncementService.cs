using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class AnnouncementService
{
    private readonly ApplicationDbContext _context;

    public AnnouncementService(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool CompleteAnnouncement(int announcementId, int userId)
    {
        var announcement = _context.Announcements.Find(announcementId);

        if (announcement == null)
        {
            return false;
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user != null)
                {
                    // İlanı tamamlayan kullanıcının hesabına ilan ücretini ekle
                    user.Balance += announcement.Price;

                    var publisher = _context.Users.FirstOrDefault(u => u.UserId == announcement.PublishedByUserId);

                    if (publisher != null && publisher.Balance >= announcement.Price)
                    {
                        // İlanı yayınlayan kullanıcının hesabından ilan ücreti kadar düşür
                        publisher.Balance -= announcement.Price;

                        announcement.IsActive = false;

                        // İlanı sil
                        _context.Announcements.Remove(announcement);

                        // Diğer işlemleri burada gerçekleştir (veritabanı güncellemeleri, loglama vb.)
                        // ...

                        // Güncellenmiş veritabanı işlemleri
                        _context.Entry(user).State = EntityState.Modified;
                        _context.Entry(publisher).State = EntityState.Modified;

                        _context.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                    else
                    {
                        // İlanı yayınlayan kullanıcının bakiyesi yetersizse, uygun bir işlem yap veya hata mesajını göster
                        // ...

                        transaction.Rollback();
                        return false;
                    }
                }
                else
                {
                    // Kullanıcı bulunamazsa, uygun bir işlem yap veya hata mesajını göster
                    // ...

                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                // İşlem sırasında bir hata olursa, işlemleri geri al
                transaction.Rollback();
                throw;
            }
        }
    }
}
