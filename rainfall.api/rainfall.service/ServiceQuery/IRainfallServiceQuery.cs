using rainfall.domain.Dto;
using rainfall.domain.Wrapper;

namespace rainfall.service.ServiceQuery
{
    public interface IRainfallServiceQuery
    {
        Task<AutoWrap> GetFloodById(RainfallByIdDTO request);
    }
}