using Microsoft.AspNetCore.Mvc;
using rainfall.domain.Wrapper;
using rainfall.domain.Dto;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet, Route("flood-monitoring/id/floods"),]
        public async Task<AutoWrap> GetFilteredFloods([FromQuery] RainfallLimitDTO request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// The number of readings to return
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet, Route("flood-monitoring/id/floods/{floodId}"),]
        public async Task<AutoWrap> GetFilteredFloods1(string floodId)
        {
            return await _mediator.Send(new RainfallByIdDTO { FloodId = floodId});
        }
    }
}
