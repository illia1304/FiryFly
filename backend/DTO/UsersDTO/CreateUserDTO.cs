using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace backend.DTO.UserDTO
{
    public class CreateUserDTO
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Surname{get;set;}

        [Required]
        [MaxLength(100)]
        public string? Nickname { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Email{get;set;}    
    }
}