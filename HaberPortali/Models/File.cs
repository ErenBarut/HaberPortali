using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortali.Models
{
    public class File
    {
        public int Id { get; set; }
        public string File_Name { get; set; }
        public string FilePath { get; set; }
        public DateTime Created {  get; set; }
        public DateTime Updated { get; set; }   

        [ForeignKey("AppUser")]
        public string UserId { get; set; }

        public AppUser AppUser { get; set; }   
        public List<News> News { get; set; }

    }
}
