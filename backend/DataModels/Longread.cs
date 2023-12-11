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
        public string? content_text { get; set; }
        [ForeignKey(nameof(autor_id))]
        [Column("autor_id")]
        public User autor { get; set; } = new User();
        public int autor_id { get; set; }
        
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("edit")]
        public DateTime Edit { get; set; }
        [Column("likes")]
        public int Likes { get; set; }
    }
}