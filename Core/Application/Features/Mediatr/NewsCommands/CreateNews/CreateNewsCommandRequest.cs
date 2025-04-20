using Domain.Entities;
using Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.CreateNews
{
    public class CreateNewsCommandRequest : BaseEntity, IRequest<CreateNewsCommandResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsAIGenerated { get; set; } = false;
        public string? AiSource { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
