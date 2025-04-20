using Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagCommands.UpdateTag
{
    public class UpdateTagCommandRequest : BaseEntity, IRequest<UpdateTagCommandResponse>
    {
        public string Name { get; set; }

    }

}
