using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreAppSkeleton.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Blog> _blogs;
        private ICollection<Post> _posts;

        public User()
        {
            Blogs = new HashSet<Blog>();
            Posts = new HashSet<Post>();
        }

        public virtual ICollection<Blog> Blogs
        {
            get { return _blogs; }
            set { _blogs = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }
    }
}