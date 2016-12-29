using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreAppSkeleton.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<BlogPost> _posts;

        public User()
        {
            Posts = new HashSet<BlogPost>();
        }

        public string ShortBio { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<BlogPost> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }
    }
}