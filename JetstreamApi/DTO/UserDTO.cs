using System.ComponentModel.DataAnnotations;
using JetstreamApi.Common;

namespace JetstreamApi.DTO
{
    /// <summary>
    /// Data transfer object for a user
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public Roles Role { get; set; }

        public bool IsLocked { get; set; }
    }
}
