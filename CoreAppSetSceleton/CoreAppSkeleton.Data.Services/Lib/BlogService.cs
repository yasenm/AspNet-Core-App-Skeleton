using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.DataConsole.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Data.Services.Lib
{
    public class BlogService : IBlogService
    {
        private ICoreAppSkeletonData _data;

        public BlogService(ICoreAppSkeletonData data)
        {
            _data = data;
        }

        public IQueryable<T> GetAll<T>()
        {
            var result = _data.Blogs.All()
                .OrderByDescending(b => b.CreatedOn)
                .ProjectTo<T>();
            return result;
        }

        public IQueryable<T> GetAllByAuthor<T>(string authorName)
        {
            var result = _data.Blogs.All()
                .OrderByDescending(b => b.CreatedOn)
                .Where(b => b.Author.UserName == authorName)
                .ProjectTo<T>();
            return result;
        }
    }
}
