using System.Linq;

using CoreAppSkeleton.Data.ViewModels;
using CoreAppSkeleton.DataConsole.Repository.Contracts;

using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace CoreAppSkeleton.DataConsole.Repository
{
    public class CoreModelRepository : ICoreModelRepository
    {
        private ICoreAppSkeletonDbContext _context;

        public CoreModelRepository(ICoreAppSkeletonDbContext context)
        {
            _context = context;
        }

        public IQueryable<CoreAppViewModel> GetAll()
        {
            return this._context.CoreAppModels.ProjectTo<CoreAppViewModel>();
        }

        public CoreAppViewModel GetById(int id)
        {
            var coreappmodel = this._context.CoreAppModels.FirstOrDefault(cam => cam.Id == id);
            var model = Mapper.Map<CoreAppViewModel>(coreappmodel);

            return model;
        }
    }
}
