using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogCommands.CreateAiLogCommands
{
    public class CreateAiLogCommandResponse : BaseEntity
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string SourceModel { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
