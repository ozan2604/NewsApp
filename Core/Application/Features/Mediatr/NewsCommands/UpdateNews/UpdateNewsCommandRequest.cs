using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.UpdateNews
{
    public class UpdateNewsCommandRequest : IRequest<UpdateNewsCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string? AiSource { get; set; }
        
        public List<Guid> SelectedTagIds { get; set; } = new();
        public List<Guid> SelectedCategoryIds { get; set; } = new();
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

       
    }
}
