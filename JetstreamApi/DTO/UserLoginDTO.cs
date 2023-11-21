using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    /// <summary>
    /// Data transfer object for a user login DTO
    /// </summary>
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
