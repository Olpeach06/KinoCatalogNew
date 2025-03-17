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
        [Display(Name = "Название")]
        public string? Title { get; set; }

        [StringLength(500)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Column(TypeName = "date")] // Если дата выпуска указана как год
        [Display(Name = "Год релиза")]
        public DateTime? ReleaseYear { get; set; }

        [Required]
        [Display(Name = "Продолжительность")]
        public int Duration { get; set; }

        [StringLength(10)] // Тип данных nvarchar(10)
        [Display(Name = "Рейтинг")]
        public string? Rating { get; set; }

        [Url]
        [Display(Name = "URL - адрес изображения")]
        public string? PosterURL { get; set; }

        public int GenreID { get; set; }

        [ForeignKey(nameof(GenreID))]
        [Display(Name = "Жанр")]
        public Genre? Genre { get; set; }

        public int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        [Display(Name = "Страна")]
        public Country? Country { get; set; }

        // Новые свойства
        public int ActorID { get; set; }

        [ForeignKey(nameof(ActorID))]
        [Display(Name = "Актер")]
        public Actor? Actor { get; set; }

        public int StudioID { get; set; }

        [ForeignKey(nameof(StudioID))]
        [Display(Name = "Продакшн-студио")]
        public ProductionStudio? Studio { get; set; }
    }
}
