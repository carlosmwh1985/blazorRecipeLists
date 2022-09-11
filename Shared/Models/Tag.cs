using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CKSummary.Shared.Models
{
    [Table("tbl_tags_ckm")]
    public class Tag
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("count_recp")]
        public int Count { get; set;}

    }
}