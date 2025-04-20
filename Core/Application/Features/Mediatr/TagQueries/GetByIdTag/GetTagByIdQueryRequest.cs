using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagQueries.GetByIdTag
{
    public class GetTagByIdQueryRequest : IRequest<GetTagByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
