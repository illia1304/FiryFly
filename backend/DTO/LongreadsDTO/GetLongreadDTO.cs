using System;
using System.ComponentModel.DataAnnotations;
using backend.DTO.UserDTO;
using Microsoft.AspNetCore.Http;

namespace backend.DTO.LongreadsDTO
{
    public class GetLongreadDTO
    {
        [Required]
        [MaxLength(250)]
        public string? Title { get; set; }

        public int AutorId { get; set; }
        public DateTime CreatedAt {  get; set; }

    }
}