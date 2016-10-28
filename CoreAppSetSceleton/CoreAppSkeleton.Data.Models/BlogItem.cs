using CoreAppSkeleton.Data.Common.Models;

namespace CoreAppSkeleton.Data.Models
{
    public class BlogItem : DescribableEntity
    {
        public int Id { get; set; }
        public long AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
