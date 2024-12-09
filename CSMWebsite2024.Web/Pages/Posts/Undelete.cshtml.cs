using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.Data.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSMWebsite2024.Web.Pages.Posts
{
    public class Undelete : PageModel
    {
        [BindProperty]
        public Post? Item { get; set; }
        private readonly ILogger<Index> _logger;
        private readonly IPostService _postService;

        public Undelete(ILogger<Index> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public async Task OnGet(Guid? id = null)
        {
            if(id == null)
            {
                Item = null;
                return;
            }
            else
            {
                Item = await _postService.GetByIdAsync(id);
                return;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (Item == null)
            {
                Item = null;
                return Page();
            }
            else
            {
                Item.IsDeleted = false;

                await _postService.UndeleteAsync(Item.Id);
                return RedirectPermanent("~/posts?sortBy=DateUpdated&sortAsc=false");                
            }
        }
    }
}
