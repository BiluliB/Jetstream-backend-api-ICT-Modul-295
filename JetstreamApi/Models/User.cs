using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int PasswordInputAttempt { get; set; } = 0;

        public bool IsLocked { get; set; }
    }
}
