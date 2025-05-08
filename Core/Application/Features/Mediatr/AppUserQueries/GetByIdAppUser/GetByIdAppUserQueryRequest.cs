using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserQueries.GetByIdAppUser
{
    public class GetByIdAppUserQueryRequest : IRequest<GetByIdAppUserQueryResponse>
    {
        public Guid Id { get; set; }
    }
}