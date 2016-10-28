using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.DataConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Data.Services.Lib
{
    public class BlogItemsService : IBlogItemsService
    {
        private CoreAppSkeletonDbContext _context;

        public BlogItemsService(CoreAppSkeletonDbContext context)
        {
            _context = context;
        }

        public IQueryable<TViewModel> GetAll<TViewModel>()
        {
            var result = _context.BlogItems
                .ProjectTo<TViewModel>();

            return result;
        }

        public TViewModel GetById<TViewModel>(int id)
        {
            var model = _context.BlogItems.FirstOrDefault(bi => bi.Id == id);
            if (model != null)
            {
                var result = Mapper.Map<TViewModel>(model);
                return result;
            }

            return default(TViewModel);
        }
    }
}
