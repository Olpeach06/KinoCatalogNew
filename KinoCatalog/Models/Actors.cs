using System.ComponentModel.DataAnnotations;

namespace KinoCatalog.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
    }
}
