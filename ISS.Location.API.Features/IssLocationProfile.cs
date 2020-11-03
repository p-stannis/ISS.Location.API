using AutoMapper;
using ISS.Location.API.Entities;

namespace ISS.Location.API.Features
{
    public class IssLocationProfile : Profile
    {
        public IssLocationProfile()
        {
            CreateMap<IssLocationModel, IssLocation>()
                .ForMember(dest => dest.Latitude, opts => opts.MapFrom(source => source.IssPosition.Latitude))
                .ForMember(dest => dest.Longitude, opts => opts.MapFrom(source => source.IssPosition.Longitude));

            CreateMap<IssLocation, IssLocationModel>()
                .ForPath(dest => dest.IssPosition.Latitude, opts => opts.MapFrom(source => source.Latitude))
                .ForPath(dest => dest.IssPosition.Longitude, opts => opts.MapFrom(source => source.Longitude));

            CreateMap<IssLocationApi, IssLocation>();

            CreateMap<IssLocationApi, IssLocationModel>();

            CreateMap<IssLocationModel, IssLocationApi>();

        }
    }
}
