﻿using System.ComponentModel.DataAnnotations;
using JetstreamApi.Common;

namespace JetstreamApi.Models
{
    /// <summary>
    /// Model for a user
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int PasswordInputAttempt { get; set; } = 0;

        public bool IsLocked { get; set; }

        public Roles Role { get; set; }
    }
}
