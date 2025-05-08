using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsCommands.UpdateAiLogsCommand
{
    public class UpdateAiLogsCommandRequest : IRequest<UpdateAiLogsCommandResponse>
    {
        public Guid Id { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string? SourceModel { get; set; }
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
