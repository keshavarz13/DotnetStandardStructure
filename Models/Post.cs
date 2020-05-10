using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(length: 1200)]
        public string Name { get; set; }
    }
}