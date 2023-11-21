using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    /// <summary>
    /// Data transfer object for updating a service request DTO
    /// </summary>
    public class ServiceRequestUpdateDTO
    {
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
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid phone number")]
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
    }
}
