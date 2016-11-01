﻿using AutoMapper;
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
    public class PostService : IPostService
    {
        private ICoreAppSkeletonData _data;

        public PostService(ICoreAppSkeletonData data)
        {
            _data = data;
        }

        public IQueryable<TViewModel> GetAll<TViewModel>()
        {
            var result = _data.Posts.All()
                .ProjectTo<TViewModel>();

            return result;
        }

        public TViewModel GetById<TViewModel>(int id)
        {
            var model = _data.Posts.All().FirstOrDefault(bi => bi.Id == id);
            if (model != null)
            {
                var result = Mapper.Map<TViewModel>(model);
                return result;
            }

            return default(TViewModel);
        }
    }
}