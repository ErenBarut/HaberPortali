using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortali.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("Files")]
        public int? FileId { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; } 

        [ForeignKey("AppUsers")]
        public string UserId { get; set; }
        public File Files { get; set; }
        public Category Categories { get; set; }
        public AppUser AppUser { get; set; }
    }
}
