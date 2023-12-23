using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace backend.DataModels
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int User_id { get; set; }

        [Required]
        [Column("name")]
        public string? Name { get; set; }

        [Column("surname")]
        public string? Surname { get; set; }

        [Required]
        [Column("nickname")]
        public string? Nickname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column ("passwordHash")]
        public string? PasswordHash { get; set; }
    }
}