using System.ComponentModel.DataAnnotations;

namespace KinoCatalog.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
    }
}
