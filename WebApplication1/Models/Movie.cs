using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Movie
    {
        [MaxLength(100)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = "";
        [MaxLength(100)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string Author { get; set; } = "";
        [MaxLength(100)]
        public string Genre { get; set; } = "";

        [Precision(16,2)]
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}
