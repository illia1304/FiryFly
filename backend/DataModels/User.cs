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
        [Column("name")]
        public string? Name { get; set; }
        [Column("surname")]
        public string? Surname { get; set; }
        [Column("nickname")]
        public string? Nickname { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        
        [Column("followers_count")]
        public int Followers_count { get; set; }
    }
}