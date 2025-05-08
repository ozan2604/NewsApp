using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsCommands.CreateAiLogsCommand
{
    public class CreateAilogsCommandRequest : IRequest<CreateAiLogsCommandResponse>
    {
        public string Prompt { get; set; }
        public string SourceModel { get; set; }
        
    }
    
}
