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
            .Property(a => a.Price)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<UserModel>()
            .Property(u => u.Balance)
            .HasColumnType("decimal(18, 2)");
    }

}
