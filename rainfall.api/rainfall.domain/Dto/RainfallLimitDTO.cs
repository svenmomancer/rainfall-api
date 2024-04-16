using rainfall.domain.Wrapper;
using MediatR;

namespace rainfall.domain.Dto
{
    public class RainfallLimitDTO : IRequest<AutoWrap>
    {
        public int? limit { get; set; }
    }
}
