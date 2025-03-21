﻿using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
