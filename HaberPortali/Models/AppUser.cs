using Microsoft.AspNetCore.Identity;
namespace HaberPortali.Models

{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public List<News> News { get; set; }
        public List<File> Files { get; set; }
    }
}
