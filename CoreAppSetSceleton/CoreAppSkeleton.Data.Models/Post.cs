using CoreAppSkeleton.Data.Common.Models;
using System;

namespace CoreAppSkeleton.Data.Models
{
    public class Post : DescribableEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
