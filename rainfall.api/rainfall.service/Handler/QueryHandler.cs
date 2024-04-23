using rainfall.service.ServiceQuery;
using rainfall.domain.Wrapper;
using rainfall.domain.Dto;
using MediatR;

namespace rainfall.service.Handler
{
    public class QueryHandler : IRequestHandler<RainfallByIdDTO, AutoWrap>
    {
        private readonly IRainfallServiceQuery _rainfall;
        public QueryHandler(IRainfallServiceQuery rainfall)
        {
            _rainfall = rainfall;
        }

        public async Task<AutoWrap> Handle(RainfallByIdDTO request, CancellationToken cancellationToken)
        {
            return await _rainfall.GetFloodById(request);
        }
    }
}
