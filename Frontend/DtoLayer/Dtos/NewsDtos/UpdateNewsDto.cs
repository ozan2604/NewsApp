using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.NewsDtos
{
    public class UpdateNewsDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsAIGenerated { get; set; } = false;
        public string? AiSource { get; set; }
        public string ImageUrl { get; set; }

        public Guid? AuthorId { get; set; }

        public List<Guid> CategoryIds { get; set; } = new();
        public List<Guid> TagIds { get; set; } = new();
    }
}
