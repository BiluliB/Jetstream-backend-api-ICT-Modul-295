using System.ComponentModel.DataAnnotations;
using JetstreamApi.Common;

namespace JetstreamApi.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public Roles Role { get; set; }
    }
}
