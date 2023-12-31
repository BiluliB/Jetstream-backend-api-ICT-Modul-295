﻿using JetstreamApi.Models;
using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.DTO
{
    /// <summary>
    /// Data transfer object for a service request DTO
    /// </summary>
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
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required]
        public int PriorityId { get; set; }
        public Priority Priority {  get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Service {  get; set; }

        [Required]
        public decimal Price { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
