using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.DataConsole.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Data.Services.Lib
{
    public class CoreAppModelService : ICoreAppModelService
    {
        private ICoreAppSkeletonData _data;

        public CoreAppModelService(ICoreAppSkeletonData data)
        {
            _data = data;
        }

        public IQueryable<TViewModel> GetAll<TViewModel>()
        {
            var result = _data.CoreAppModels.All()
                 .ProjectTo<TViewModel>();

            return result;
        }
    }
}
