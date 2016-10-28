using CoreAppSkeleton.Data.Common.Models;
using System;

namespace CoreAppSkeleton.Data.Models
{
    public class BlogItem : DescribableEntity
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
