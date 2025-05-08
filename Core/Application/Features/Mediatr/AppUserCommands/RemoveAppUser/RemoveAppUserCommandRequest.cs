using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserCommands.RemoveAppUser
{
    public class RemoveAppUserCommandRequest : IRequest<RemoveAppUserCommandResponse>
    {
        public Guid Id { get; set; }
    }
    
}
