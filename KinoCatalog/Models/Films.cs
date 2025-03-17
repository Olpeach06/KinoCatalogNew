using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinoCatalog.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "date")] // Если дата выпуска указана как год
        public DateTime? ReleaseYear { get; set; }

        [Required]
        public int Duration { get; set; }

        [StringLength(10)] // Тип данных nvarchar(10)
        public string? Rating { get; set; }

        [Url]
        public string? PosterURL { get; set; }

        public int GenreID { get; set; }

        [ForeignKey(nameof(GenreID))]
        public Genre? Genre { get; set; }

        public int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        public Country? Country { get; set; }

        // Новые свойства
        public int ActorID { get; set; }

        [ForeignKey(nameof(ActorID))]
        public Actor? Actor { get; set; }

        public int StudioID { get; set; }

        [ForeignKey(nameof(StudioID))]
        public ProductionStudio? Studio { get; set; }
    }
}
