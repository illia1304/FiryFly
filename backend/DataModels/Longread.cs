using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace backend.DataModels
{
    public class Longread
    {
        [Key]
        [Column("longread_id")]
        public int Longread_id { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("content_text")]
        public string? Content_text { get; set; }
        [ForeignKey(nameof(Author_id))]
        public User Author { get; set; } = new User();
        [Column("author_id")]
        public int Author_id { get; set; }
        
        [Column("created")]
        public DateTime Created { get; set; }
    }
}