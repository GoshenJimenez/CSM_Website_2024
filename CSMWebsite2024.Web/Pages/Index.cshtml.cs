using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.Data.Posts;
using CSMWebsite2024.Data.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSMWebsite2024.Web.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IPostService _postService;
        public List<Post> Posts { get; set; }

        public Index(ILogger<Index> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public async Task OnGet()
        {
            Posts = (await _postService.GetAllAsync()).ToList();
        }
    }
}
