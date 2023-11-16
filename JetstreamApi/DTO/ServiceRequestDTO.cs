using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    public class ServiceRequestDTO
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
        public int StatusId { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
