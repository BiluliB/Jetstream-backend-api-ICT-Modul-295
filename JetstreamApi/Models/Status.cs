using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    /// <summary>
    /// Model for a status
    /// </summary>
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }
    }
}
