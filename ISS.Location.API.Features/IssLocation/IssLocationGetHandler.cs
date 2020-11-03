using AutoMapper;
using ISS.Location.API.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ISS.Location.API.Features
{
    public class IssLocationGetHandler : IRequestHandler<IssLocationGetRequest, IssLocationModel>
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ILocationApiRepository _apiRepo;

        #endregion

        #region Constructors
        public IssLocationGetHandler(IMapper mapper, ILocationApiRepository apiRepo, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _apiRepo = apiRepo;
        }
        #endregion

        public async Task<IssLocationModel> Handle(IssLocationGetRequest request, CancellationToken cancellationToken)
        {
            var currentLocation = await _apiRepo.GetLocation();

            if (currentLocation == null) return new IssLocationModel();

            var result = _mapper.Map<IssLocationModel>(currentLocation);

            return result;
        }
    }
}
