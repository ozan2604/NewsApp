using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.RemoveNews
{
    public class RemoveNewsCommandRequest : IRequest<RemoveNewsCommandResponse>
    {
        public string Id { get; set; }
    }
    
}
