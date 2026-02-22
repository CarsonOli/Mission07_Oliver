using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission07_Oliver.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year after 1887")]
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        public string Notes { get; set; }
    }
}
