using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetByIdNews
{
    public class GetByIdNewsQueryRequest : IRequest<GetByIdNewsQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
