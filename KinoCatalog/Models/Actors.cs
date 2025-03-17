using System.ComponentModel.DataAnnotations;

namespace KinoCatalog.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }
    }
}
