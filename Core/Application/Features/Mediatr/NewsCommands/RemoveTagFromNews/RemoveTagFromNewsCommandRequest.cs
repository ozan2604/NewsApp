using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.RemoveTagFromNews
{
    public class RemoveTagFromNewsCommandRequest : IRequest<RemoveTagFromNewsCommandResponse>
    {
        public Guid NewsId { get; set; }
        public Guid TagId { get; set; }
    }
}
