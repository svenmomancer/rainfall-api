using rainfall.domain.Dto;
using rainfall.domain.Wrapper;

namespace rainfall.service.ServiceQuery
{
    public interface IRainfallServiceQuery
    {
        Task<AutoWrap> GetListFlood(RainfallLimitDTO request);
        Task<AutoWrap> GetFloodById(RainfallByIdDTO request);
    }
}