﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsQueries.GetAllAiLogs
{
    public class GetAiLogsQueryRequest : IRequest<List<GetAiLogsQueryResponse>>  
    {
    }
}
