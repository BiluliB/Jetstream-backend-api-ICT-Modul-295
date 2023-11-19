using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }


        [Required]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        [StringLength(500)]
        public string? Comment { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
