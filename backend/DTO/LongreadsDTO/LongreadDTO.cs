using System;
using System.ComponentModel.DataAnnotations;
using backend.DTO.UserDTO;
using Microsoft.AspNetCore.Http;

namespace backend.DTO.LongreadsDTO
{
    public class LongreadDTO
    {
        [Required]
        [MaxLength(250)]
        public string? Title { get; set; }

        [Required]
        public string? Content {  get; set; }

        //public DateTime CreatedAt {  get; set; }
        public int AuthorId { get; set; } 

    }
}