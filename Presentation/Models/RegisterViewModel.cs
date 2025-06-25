﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        
        public string Password { get; set; } = default!;

      
    }
}
