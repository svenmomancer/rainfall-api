using rainfall.data.RepositoryQuery;
using rainfall.domain.Wrapper;
using rainfall.domain.Model;
using AutoWrapper.Wrappers;
using rainfall.domain.Dto;
using AutoMapper;

namespace rainfall.service.ServiceQuery
{
    public class RainfallServiceQuery : IRainfallServiceQuery
    {
        private readonly IRainfallRepositoryQuery _rainfall;
        public RainfallServiceQuery(IRainfallRepositoryQuery rainfall)
        {
            _rainfall = rainfall;
        }

        public async Task<AutoWrap> GetFloodById(RainfallByIdDTO request)
        {
            try
            {
                // maps dto to model
                var map = new MapperConfiguration(x => x.CreateMap<RainfallByIdDTO, RainfallByIdModel>())
                                                        .CreateMapper().Map<RainfallByIdModel>(request);

                // calls GetFloodByIdAsync repository method
                var result = await _rainfall.GetFloodByIdAsync(map);

                // I use the AutoWrapper Exception for the 400, 404 or 500 response code
                if (result is null) throw new ApiException("No readings found for the specified stationId", 404);

                return new AutoWrap(result, 200);
            }
            catch (ApiException ex) { throw ex; }
            catch (Exception ex) { throw new ApiException("Internal server error", 500); }
        }
    }
}
