using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ServiceName { get; set; }
    }
}
