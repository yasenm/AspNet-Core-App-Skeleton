using CoreAppSkeleton.Data.Common.Models;
using System.Collections.Generic;

namespace CoreAppSkeleton.Data.Models
{
    public class Blog : DescribableEntity
    {
        private ICollection<Post> _posts;

        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Post> Posts
        {
            get { return _posts; }
            private set { _posts = value; }
        }
    }
}
