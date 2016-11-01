using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Models;
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

        public async Task<bool> Add<T>(T viewModel)
        {
            var model = Mapper.Map<CoreAppModel>(viewModel);
            _data.CoreAppModels.Add(model);
            return (await _data.SaveChangesAsync()) > 0;
        }

        public IQueryable<TViewModel> GetAll<TViewModel>()
        {
            var result = _data.CoreAppModels.All()
                 .ProjectTo<TViewModel>();

            return result;
        }
    }
}
