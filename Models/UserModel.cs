using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASAG_ILIK_nvOM.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsEmployer { get; set; }
        public decimal Balance { get; set; }


    }
}
