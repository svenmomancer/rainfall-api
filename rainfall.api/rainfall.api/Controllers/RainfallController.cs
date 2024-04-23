using Microsoft.AspNetCore.Mvc;
using rainfall.domain.Wrapper;
using rainfall.domain.Dto;
using MediatR;

namespace rainfall.api.Controllers
{
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RainfallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// The number of readings to return
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("rainfall/{floodId}"),]
        public async Task<AutoWrap> GetFilteredFloods1(string floodId)
        {
            return await _mediator.Send(new RainfallByIdDTO { FloodId = floodId});
        }
    }
}
