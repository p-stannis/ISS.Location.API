using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISS.Location.API.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISS.Location.API.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IssLocationModel> Get()
        {
            var request = new IssLocationGetRequest();

            var result = await _mediator.Send(request);

            return result;
        }
    }
}
