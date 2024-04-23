using rainfall.domain.Model;
using rainfall.domain.ViewModel;

namespace rainfall.data.RepositoryQuery
{
    public interface IRainfallRepositoryQuery
    {
        Task<FloodDataViewModel> GetFloodByIdAsync(RainfallByIdModel request);
    }
}