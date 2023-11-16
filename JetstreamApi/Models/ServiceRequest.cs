using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Required]
        public int StatusId { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }


        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        [ForeignKey("PriorityId")]
        public virtual Priority Priority { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}
