using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMWebsite2024.Data.Posts
{
    public class Post
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? AuthorId { get; set; }
        //public bool? IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
