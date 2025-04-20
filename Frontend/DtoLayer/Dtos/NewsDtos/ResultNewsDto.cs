using Domain.Entities;
using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.NewsDtos
{
    public class ResultNewsDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsAIGenerated { get; set; } = false;
        public string? AiSource { get; set; }
        public string ImageUrl { get; set; }

        
        public Guid? AuthorId { get; set; }
        public string? AuthorName { get; set; } 

        
        public List<string> CategoryNames { get; set; } = new();
        public List<string> TagNames { get; set; } = new();
    }
}
