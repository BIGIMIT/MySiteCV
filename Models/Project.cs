using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bortsevych.Models
{   
    [Index(nameof(Title))]
    public class Project
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        public string Languages { get; set; } = "";
        public string HTMLPage { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
