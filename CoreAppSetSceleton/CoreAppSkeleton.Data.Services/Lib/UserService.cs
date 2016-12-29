using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.DataConsole.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoreAppSkeleton.Data.Services.Lib
{
    public class UserService : IUserService
    {
        private ICoreAppSkeletonData _data;

        public UserService(ICoreAppSkeletonData data)
        {
            _data = data;
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>()
        {
            var result = _data.Users.All()
                .ProjectTo<TViewModel>()
                .ToList();

            return result;
        }

        public TViewModel GetByUserName<TViewModel>(string username)
        {
            var user = _data.Users.All()
                .FirstOrDefault(u => u.UserName == username);
            var result = AutoMapper.Mapper.Map<TViewModel>(user);

            return result;
        }
    }
}
