using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
