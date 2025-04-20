using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagCommands.RemoveTag
{
    public class RemoveTagCommandRequest : IRequest<RemoveTagCommandResponse>
    {
        public Guid Id { get; set; }
    }
    
}
