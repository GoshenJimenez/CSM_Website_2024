using CSMWebsite2024.Contracts.Posts;
using CSMWebsite2024.Data.Posts;
using CSMWebsite2024.Data.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace CSMWebsite2024.Web.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IPostService _postService;
        public List<Post> Posts { get; set; }

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }

        public Index(ILogger<Index> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public async Task OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true", int pageSize = 5, int pageIndex = 1)
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }

            var posts = (await _postService.GetAllAsync()).ToList();

            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                if (SearchParams.SearchBy.ToLower() == "title")
                {
                    posts = posts.Where(b => b.Title!.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "description")
                {
                    posts = posts.Where(b => b.Description!.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
            }
            else if (string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                posts = posts.Where(b => b.Title!.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                Posts = posts;
                goto page;
            }

            if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == true)
            {
                Posts = posts.OrderBy(b => b.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == false)
            {
                Posts = posts.OrderByDescending(b => b.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "description" && SearchParams.SortAsc == false)
            {
                Posts = posts.OrderBy(b => b.Description).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "description" && SearchParams.SortAsc == false)
            {
                Posts = posts.OrderByDescending(b => b.Description).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "dateupdated" && SearchParams.SortAsc == true)
            {
                Posts = posts.OrderBy(b => b.UpdatedAt).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "dateupdated" && SearchParams.SortAsc == false)
            {
                Posts = posts.OrderByDescending(b => b.UpdatedAt).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "datecreated" && SearchParams.SortAsc == true)
            {
                Posts = posts.OrderBy(b => b.CreatedAt).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "datecreated" && SearchParams.SortAsc == false)
            {
                Posts = posts.OrderByDescending(b => b.CreatedAt).ToList();
            }
            else
            {
                Posts = posts;
            }

        page:
            // Paging
            int totalPages = (int)Math.Ceiling((double)Posts.Count / SearchParams.PageSize.Value);
            int skip = (SearchParams.PageIndex.Value - 1) * SearchParams.PageSize.Value;
            Posts = Posts.Skip(skip).Take(SearchParams.PageSize.Value).ToList();
            SearchParams.PageCount = totalPages;
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
            public int? PageSize { get; set; }
            public int? PageIndex { get; set; }
            public int? PageCount { get; set; }
        }
    }
}
