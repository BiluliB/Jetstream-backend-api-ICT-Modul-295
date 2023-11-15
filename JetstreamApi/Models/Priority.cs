using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class Priority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PriorityName { get; set; }
    }
}
