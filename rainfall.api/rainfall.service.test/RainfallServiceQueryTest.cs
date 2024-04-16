using Microsoft.Extensions.Options;
using Moq;
using rainfall.data.RepositoryQuery;
using rainfall.domain.Constants;
using rainfall.domain.Dto;
using rainfall.domain.Model;
using rainfall.domain.ViewModel;
using rainfall.domain.Wrapper;
using rainfall.service.ServiceQuery;
using System.Threading.Tasks;
using Xunit;

namespace rainfall.service.test
{
    public class RainfallServiceQueryTest
    {
        [Fact]
        public async Task GetListFlood_ReturnsAutoWrap()
        {
            // arrange mock for repository
            var mockRepository = new Mock<IRainfallRepositoryQuery>();
            var mockOptions = new Mock<IOptions<FloodMonitoringSettings>>();

            // setup mock options to return mock settings
            var dummySettings = new FloodMonitoringSettings
            {
                ListFloodUrl = "http://example.com/api/floods",
                FloodDetails = "http://example.com/api/floods/"
            };
            mockOptions.Setup(x => x.Value).Returns(dummySettings);

            // inject mock dependencies into the service
            var service = new RainfallServiceQuery(mockRepository.Object);
            var request = new RainfallLimitDTO();

            // setup mock repository to return mock data
            mockRepository
                .Setup(r => r.GetFloodsAsync(It.IsAny<RainfallLimitModel>()))
                .ReturnsAsync(new ListFloodViewModel()); // Mock repository response

            // act
            var result = await service.GetListFlood(request);

            // assert
            Assert.NotNull(result);
            Assert.IsType<AutoWrap>(result);
        }

        [Fact]
        public async Task GetFloodById_ReturnsAutoWrap()
        {
            // arrange mock for repository
            var mockRepository = new Mock<IRainfallRepositoryQuery>();
            var mockOptions = new Mock<IOptions<FloodMonitoringSettings>>();

            // setup mock options to return mock settings
            var dummySettings = new FloodMonitoringSettings
            {
                ListFloodUrl = "http://example.com/api/floods",
                FloodDetails = "http://example.com/api/floods/"
            };
            mockOptions.Setup(x => x.Value).Returns(dummySettings);

            // inject mock dependencies into the service
            var service = new RainfallServiceQuery(mockRepository.Object);
            var request = new RainfallByIdDTO();

            // setup mock repository to return mock data
            mockRepository
                .Setup(r => r.GetFloodByIdAsync(It.IsAny<RainfallByIdModel>()))
                .ReturnsAsync(new FloodDataViewModel()); // Mock repository response

            // act
            var result = await service.GetFloodById(request);

            // assert
            Assert.NotNull(result);
            Assert.IsType<AutoWrap>(result);
        }
    }
}
