using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CKSummary.Shared.Models
{   
    [Table("tbl_recipes_ckm")]
    public class Recipe
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("url_image")]
        public string UrlImage { get; set; }

        [Column("page")]
        public int Page { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("difficulty")]
        public string Difficulty { get; set; }

        [Column("duration")]
        public string Duration { get; set; }

        [Column("tags")]
        [DataType(DataType.Text)]
        public List<string> Tags { get; set; }

        [Column("ing_a")]
        public string[] IngA { get; set; }

        [Column("ing_b")]
        public string[] IngB { get; set; }

        [Column("ing_c")]
        public string[] IngC { get; set; }

        [Column("ing_d")]
        public string[] IngD { get; set; }

        [Column("ing_e")]
        public string[] IngE { get; set; }

        [Column("ing_f")]
        public string[] IngF { get; set; }

        [Column("ing_g")]
        public string[] IngG { get; set; }

        [Column("ing_h")]
        public string[] IngH { get; set; }

        [Column("ing_i")]
        public string[] IngI { get; set; }

        [Column("ing_j")]
        public string[] IngJ { get; set; }

        [Column("ing_k")]
        public string[] IngK { get; set; }

        [Column("ing_l")]
        public string[] IngL { get; set; }

        [Column("ing_m")]
        public string[] IngM { get; set; }

        [Column("ing_n")]
        public string[] IngN { get; set; }

        [Column("ing_o")]
        public string[] IngO { get; set; }

        [Column("ing_p")]
        public string[] IngP { get; set; }

        [Column("ing_q")]
        public string[] IngQ { get; set; }

        [Column("ing_r")]
        public string[] IngR { get; set; }

        [Column("ing_s")]
        public string[] IngS { get; set; }

        [Column("ing_t")]
        public string[] IngT { get; set; }

        [Column("ing_u")]
        public string[] IngU { get; set; }

        [Column("ing_v")]
        public string[] IngV { get; set; }

        [Column("ing_w")]
        public string[] IngW { get; set; }

        [Column("ing_x")]
        public string[] IngX { get; set; }

        [Column("ing_y")]
        public string[] IngY { get; set; }

        [Column("ing_z")]
        public string[] IngZ { get; set; }

        [Column("ing_ae")]
        public string[] IngAE { get; set; }

        [Column("ing_oe")]
        public string[] IngOE { get; set; }

        [Column("ing_ue")]
        public string[] IngUE { get; set; }

        [Column("ing_others")]
        public string[] IngOthers { get; set; }

    }

}