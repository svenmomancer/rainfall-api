using Microsoft.Extensions.Options;
using Moq;
using rainfall.data.RepositoryQuery;
using rainfall.domain.Constants;
using rainfall.domain.Model;
using rainfall.domain.ViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rainfall.data.test
{
    public class RainfallRepositoryQueryTest
    {
        [Fact]
        public async Task GetFloodsAsync_ReturnsListFloodViewModel()
        {
            // arrange mock repository
            var mockOptions = new Mock<IOptions<FloodMonitoringSettings>>();
            var dummySettings = new FloodMonitoringSettings
            {
                ListFloodUrl = "http://environment.data.gov.uk/flood-monitoring/id/floods",
                ListFloodLimitUrl = "http://environment.data.gov.uk/flood-monitoring/id/floods?_limit={0}"
            };
            mockOptions.Setup(x => x.Value).Returns(dummySettings);

            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());

            var repository = new RainfallRepositoryQuery(mockOptions.Object);
            var request = new RainfallLimitModel { _limit = 10 }; // or any request object you want to pass

            // act
            var result = await repository.GetFloodsAsync(request);

            // assert
            Assert.NotNull(result);
            Assert.IsType<ListFloodViewModel>(result);
        }

        [Fact]
        public async Task GetFloodByIdAsync_ReturnsFloodDataViewModel()
        {
            // arrange mock repository
            var mockOptions = new Mock<IOptions<FloodMonitoringSettings>>();
            var dummySettings = new FloodMonitoringSettings
            {
                FloodDetails = "http://environment.data.gov.uk/flood-monitoring/id/floods/"
            };
            mockOptions.Setup(x => x.Value).Returns(dummySettings);

            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());

            var repository = new RainfallRepositoryQuery(mockOptions.Object);
            var request = new RainfallByIdModel { FloodId = "061FAG22LamVal" }; // id

            // act
            var result = await repository.GetFloodByIdAsync(request);

            // assert
            Assert.NotNull(result);
            Assert.IsType<FloodDataViewModel>(result);
        }
    }
}
