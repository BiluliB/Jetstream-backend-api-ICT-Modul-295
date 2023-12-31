﻿using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    /// <summary>
    /// Model for a service
    /// </summary>
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ServiceName { get; set; }

        [Required]
        public decimal Price {  get; set; }
    }
}
