using AutoMapper;
using ISS.Location.API.Entities;

namespace ISS.Location.API.Features
{
    public class IssLocationProfile : Profile
    {
        public IssLocationProfile()
        {
            CreateMap<IssLocation, IssLocationModel>();
            CreateMap<IssLocationModel, IssLocation>();
            CreateMap<LocationApi, IssLocation>();
            CreateMap<LocationApi, IssLocationModel>();
            CreateMap<IssLocationModel, LocationApi>();

        }
    }
}
