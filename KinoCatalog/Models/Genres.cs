using System.ComponentModel.DataAnnotations;

namespace KinoCatalog.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Жанр")]
        public string? Name { get; set; }
    }
}
