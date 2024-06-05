namespace HaberPortaliFrontend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? FileId { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
