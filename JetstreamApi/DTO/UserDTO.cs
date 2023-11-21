using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    /// <summary>
    /// Data transfer object for a user DTO
    /// </summary>
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
