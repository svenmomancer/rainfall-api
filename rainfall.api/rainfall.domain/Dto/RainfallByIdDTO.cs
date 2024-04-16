using MediatR;
using rainfall.domain.Wrapper;

namespace rainfall.domain.Dto
{
    public class RainfallByIdDTO : IRequest<AutoWrap>
    {
        public string FloodId { get; set; }
    }
}
