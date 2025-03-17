using System.ComponentModel.DataAnnotations;

namespace KinoCatalog.Models
{
    public class ProductionStudio
    {
        [Key]
        public int StudioID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
    }
}
