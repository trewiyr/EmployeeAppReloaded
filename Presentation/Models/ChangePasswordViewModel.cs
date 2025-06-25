﻿using System.ComponentModel.DataAnnotations;
namespace Data.Model;
public class ChangePasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Current Password")]
    public string? OldPassword { get; set; } 

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "New Password")]
    public string? NewPassword { get; set; } 

    [DataType(DataType.Password)]
    [Display(Name = "Confirm New Password")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation do not match.")]
    public string ?ConfirmPassword { get; set; } 
}
