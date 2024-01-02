// Models/AnnouncementModel.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace ASAG_ILIK_nvOM.Models
{
    public class AnnouncementModel
    {
        [Key]
        public int AnnouncementId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}
