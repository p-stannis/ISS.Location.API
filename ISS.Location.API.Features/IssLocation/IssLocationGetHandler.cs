using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ISS.Location.API.Contracts;
using MediatR;

namespace ISS.Location.API.Features
{
    public class IssLocationGetHandler : IRequestHandler<IssLocationGetRequest,IssLocationModel>
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ILocationApiRepository _apiRepo;
        //private readonly IRepositoryWrapper _repository;
        
        #endregion

        #region Constructors
        public IssLocationGetHandler(IMapper mapper, ILocationApiRepository apiRepo)
        {
            _mapper = mapper;
            _apiRepo = apiRepo;
            //_repository = repository;
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
