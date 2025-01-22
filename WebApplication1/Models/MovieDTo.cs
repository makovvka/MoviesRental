using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MovieDTo
    {
        [Required,MaxLength(100)]
        public string Title { get; set; } = "";
        [Required,MaxLength(100)]
        public string Description { get; set; } = "";
        [Required, MaxLength(100)]
        public string Author { get; set; } = "";
        [Required, MaxLength(100)]
        public string Genre { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
