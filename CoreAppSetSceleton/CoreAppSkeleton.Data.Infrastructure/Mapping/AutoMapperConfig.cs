using AutoMapper;

using CoreAppSkeleton.Data.Models;
using CoreAppSkeleton.Data.ViewModels;

namespace CoreAppSkeleton.Data.Infrastructure.Mapping
{
    public static class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CoreAppModel, CoreAppViewModel>()
                // Custom field mapping tested and working !! :)
                    .ForMember(dest => dest.Description123, opt => opt.MapFrom(src => src.Description))
                    .ReverseMap();

                cfg.CreateMap<Post, PostLinkBigViewModel>()
                    .ReverseMap();
            });
        }
    }
}
