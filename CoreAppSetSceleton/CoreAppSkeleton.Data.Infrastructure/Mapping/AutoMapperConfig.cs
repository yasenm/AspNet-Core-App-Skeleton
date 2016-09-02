using AutoMapper;

using CoreAppSkeleton.Data.Models;
using CoreAppSkeleton.Data.ViewModels;

namespace CoreAppSkeleton.Data.Infrastructure.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CoreAppModel, CoreAppViewModel>().ReverseMap();
        }
    }
}
