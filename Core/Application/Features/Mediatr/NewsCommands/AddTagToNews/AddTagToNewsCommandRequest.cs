using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.AddTagToNews
{
    public class AddTagToNewsCommandRequest : IRequest<AddTagToNewsCommandResponse>
    {
        public Guid NewsId { get; set; }
        public Guid TagId { get; set; }
    }
}
