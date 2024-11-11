using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.Data.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSMWebsite2024.Web.Pages.Posts
{
    public class Create : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IPostService _postService;

        public Create(ILogger<Index> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }


        [BindProperty]
        public Post? Item { get; set; }

        public void OnGet()
        {
            this.Item = new Post();
        }

        public async Task OnPost()
        {
            if (this.Item == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.Item.Title))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.Item.Description))
            {
                return;
            }

            this.Item.Id = Guid.NewGuid();
            this.Item.AuthorId = Guid.NewGuid();
            this.Item.UpdatedAt = DateTime.Now;
            this.Item.CreatedAt = DateTime.Now;

            await _postService.AddAsync(this.Item);

            RedirectPermanent("~/posts");
        }

    }
}
