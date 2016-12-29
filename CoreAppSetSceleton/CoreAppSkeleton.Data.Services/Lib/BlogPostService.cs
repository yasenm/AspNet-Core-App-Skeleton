using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.DataConsole;
using CoreAppSkeleton.DataConsole.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Data.Services.Lib
{
    public class BlogPostService : IBlogPostService
    {
        private ICoreAppSkeletonData _data;

        public BlogPostService(ICoreAppSkeletonData data)
        {
            _data = data;
        }

        public IQueryable<TViewModel> GetAll<TViewModel>()
        {
            var result = _data.BlogPosts.All()
                .ProjectTo<TViewModel>();

            return result;
        }

        public TViewModel GetById<TViewModel>(int id)
        {
            var model = _data.BlogPosts.All()
                .Where(bi => bi.Id == id)
                .ProjectTo<TViewModel>()
                .FirstOrDefault();
            if (model != null)
            {
                return model;
            }

            return default(TViewModel);
        }

        public ICollection<TViewModel> GetUserBlogPosts<TViewModel>(string username)
        {
            var blogPosts = _data.BlogPosts.All()
                .Where(bp => bp.Author.UserName == username)
                .ProjectTo<TViewModel>()
                .ToList();

            return blogPosts;
        }
    }
}
