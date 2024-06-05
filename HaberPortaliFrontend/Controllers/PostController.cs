using HaberPortaliFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HaberPortaliFrontend.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostApiService _postApiService;

        public PostsController(PostApiService postApiService) // Inject via constructor
        {
            _postApiService = postApiService;
        }

        public async Task<ActionResult> Index()
        {
            var posts = await _postApiService.GetPostsAsync();
            return View(posts);
        }
        
    }

}
