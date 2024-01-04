// Models/AnnouncementModel.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASAG_ILIK_nvOM.Models
{
    public class AnnouncementModel
    {
        [Key]
        public int AnnouncementId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int PublishedByUserId { get; set; }

        [Required]
        public int AcceptedByUserId { get; set; }
    }
}
