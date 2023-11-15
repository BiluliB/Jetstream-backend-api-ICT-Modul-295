using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }

    }
}
