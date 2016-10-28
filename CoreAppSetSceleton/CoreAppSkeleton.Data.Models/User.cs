using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreAppSkeleton.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<BlogItem> _blogs;

        public User()
        {
            Blogs = new HashSet<BlogItem>();
        }

        public virtual ICollection<BlogItem> Blogs
        {
            get { return _blogs; }
            set { _blogs = value; }
        }
    }
}