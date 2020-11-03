using AutoMapper;
using ISS.Location.API.Contracts;
using ISS.Location.API.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ISS.Location.API.Features
{
    public class IssLocationCreateHandler : IRequestHandler<IssLocationCreateRequest, IssLocationModel>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IRepositoryWrapper _repository;

        public IssLocationCreateHandler(IMapper mapper, IMediator mediator, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<IssLocationModel> Handle(IssLocationCreateRequest request, CancellationToken cancellationToken)
        {
            var issLocationModel = await _mediator.Send(new IssLocationGetRequest { }, cancellationToken);

            var issLocation = _mapper.Map<IssLocation>(issLocationModel);

            using (_repository.UseTransaction())
            {
                _repository.IssLocation.Create(issLocation);
            }

            var result = _mapper.Map<IssLocationModel>(issLocation);

            return result;
        }
    }
}
