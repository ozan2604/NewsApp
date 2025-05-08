using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsQueries.GetByIDAiLogs
{
    public class GetByIDAiLogsQueryRequest :IRequest<GetByIDAiLogsQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
