namespace HaberPortali.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<News> News { get; set; }
    }
}
