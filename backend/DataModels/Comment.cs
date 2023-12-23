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
        [ForeignKey(nameof(autor_id))]
        [Column("autor_id")]
        public User autor { get; set; } = new User();
        public int autor_id { get; set; }

        [ForeignKey(nameof(longread_idcoment))]
        [Column("longread_idcoment")]
        public Longread longreads { get; set; } = new Longread();
        public int longread_idcoment { get; set; }
        [Column("created")]
        public DateTime created { get; set; }
    }
}