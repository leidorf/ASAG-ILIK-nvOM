// Data/ApplicationDbContext.cs
using ASAG_ILIK_nvOM.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<AnnouncementModel> Announcements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnnouncementModel>()
            .Property(a => a.Balance)
            .HasColumnType("decimal(18,2)"); // Bu örnek varsayılan precision ve scale değerleridir, ihtiyacınıza göre düzenleyebilirsiniz

        // İlişkileri tanımlayabilirsiniz
        modelBuilder.Entity<AnnouncementModel>()
            .HasOne(a => a.User)
            .WithMany(u => u.Announcements)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
