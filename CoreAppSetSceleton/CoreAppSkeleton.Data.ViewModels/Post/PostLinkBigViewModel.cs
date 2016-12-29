using System;

namespace CoreAppSkeleton.Data.ViewModels
{
    public class BlogPostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AuthorName { get; set; }
    }
}
