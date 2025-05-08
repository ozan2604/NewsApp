using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsCommands.RemoveAiLogsCommand
{
    public class RemoveAiLogsCommandRequest : IRequest<RemoveAiLogsCommandResponse>
    {
        public Guid Id { get; set; }
    }
    
}
