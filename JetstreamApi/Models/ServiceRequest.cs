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
        public string Email { get; set;}

        [Required]
        [Phone] 
        public string Phone { get; set;}

        [Required]
        public string Priority { get; set; }

        [Required]
        public DateTime CreatDate { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public string Price { get; set; }
    }
}
