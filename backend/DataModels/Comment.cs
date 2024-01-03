using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace backend.DataModels
{
    public class Commment
    {
        [Key]
        [Column("comment_id")]
        public int Comment_id { get; set; }
        [Column("comment_text")]
        public string? Comment_text { get; set; }
        [ForeignKey(nameof(Autor_id))]
        [Column("author_id")]
        public User Author { get; set; } = new User();
        public int Autor_id { get; set; }

        [ForeignKey(nameof(Longread_idcoment))]
        [Column("longread_idcoment")]
        public Longread Longreads { get; set; } = new Longread();
        public int Longread_idcoment { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
    }
}