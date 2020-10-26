using System;
using System.Threading.Tasks;
using ISS.Location.API.Entities;

namespace ISS.Location.API.Contracts
{
    public interface ILocationApiRepository
    {
        Task<LocationApi> GetLocation();
    }
}
