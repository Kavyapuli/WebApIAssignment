using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApIAssignment.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id{ get; set; }
        [StringLength(100)]
        public string MName { get; set; }
        public string StatCast { get; set;}
        public string Director { get; set;}
        public string Producer { get; set;}
        public DateTime ReleaseDate { get; set;}
    }
}
