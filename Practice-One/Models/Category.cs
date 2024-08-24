using System.ComponentModel.DataAnnotations;

namespace Practice_One.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Letters are allowed.")]
        public string Name { get; set; }
        [Range(1,100, ErrorMessage ="Please select a number between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
