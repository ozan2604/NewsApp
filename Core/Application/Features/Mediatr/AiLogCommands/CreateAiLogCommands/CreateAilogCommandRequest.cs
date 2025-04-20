using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogCommands.CreateAiLogCommands
{
    public class CreateAilogCommandRequest : IRequest<CreateAiLogCommandResponse>
    {
        public string Prompt { get; set; }
        public string SourceModel { get; set; }
        public Guid NewsId { get; set; }
    }
    
}
