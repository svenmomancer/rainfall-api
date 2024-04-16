using Microsoft.Extensions.Options;
using rainfall.domain.Constants;
using rainfall.domain.ViewModel;
using rainfall.domain.Model;
using Newtonsoft.Json;

namespace rainfall.data.RepositoryQuery
{
    public class RainfallRepositoryQuery : IRainfallRepositoryQuery
    {
        private readonly IOptions<FloodMonitoringSettings> _url;
        public RainfallRepositoryQuery(IOptions<FloodMonitoringSettings> url)
        {
            _url = url;
        }

        public async Task<ListFloodViewModel> GetFloodsAsync(RainfallLimitModel request)
        {
            try
            {
                // i used using to auto dispose the connection
                using (var client = new HttpClient())
                {
                    // used if condition for the endpoint with or without parameter
                    var endpoint = request._limit is null ? _url.Value.ListFloodUrl : string.Format(_url.Value.ListFloodLimitUrl, request._limit);

                    // calls the method
                    var response = await client.GetAsync(endpoint);
                    
                    // converts the response to string
                    var content = await response.Content.ReadAsStringAsync();

                    // map the string response to my model
                    var result = JsonConvert.DeserializeObject<ListFloodViewModel>(content);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FloodDataViewModel> GetFloodByIdAsync(RainfallByIdModel request)
        {
            try
            {
                // i used using to auto dispose the connection
                using (var client = new HttpClient())
                {
                    // concat endpoint with the parameter 
                    var endpoint = $"{_url.Value.FloodDetails}{request.FloodId}";

                    // calls the method
                    var response = await client.GetAsync(endpoint);

                    // converts the response to string
                    var content = await response.Content.ReadAsStringAsync();

                    // map the string response to my model
                    var result = JsonConvert.DeserializeObject<FloodDataViewModel>(content);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
