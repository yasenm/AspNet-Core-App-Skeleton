using System.Linq;

using CoreAppSkeleton.Data.ViewModels;
using CoreAppSkeleton.DataConsole.Repository.Contracts;

using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;
using CoreAppSkeleton.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole.Repository
{
    public class CoreModelRepository : ICoreModelRepository
    {
        private CoreAppSkeletonDbContext _context;

        public CoreModelRepository(CoreAppSkeletonDbContext context)
        {
            _context = context;
        }

        public void Add(CoreAppViewModel postModel)
        {
            var coreAppModel = Mapper.Map<CoreAppModel>(postModel);
            _context.CoreAppModels.Add(coreAppModel);
        }

        public IQueryable<CoreAppViewModel> GetAll()
        {
            return this._context.CoreAppModels.ProjectTo<CoreAppViewModel>();
            //return this._context.CoreAppModels.Select(CoreAppViewModel.FromCoreAppModel);
        }

        public CoreAppViewModel GetById(int id)
        {
            var coreappmodel = this._context.CoreAppModels.FirstOrDefault(cam => cam.Id == id);
            var model = Mapper.Map<CoreAppViewModel>(coreappmodel);

            return model;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
