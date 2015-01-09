using System.ComponentModel.DataAnnotations;

namespace _04aModelValidation.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}