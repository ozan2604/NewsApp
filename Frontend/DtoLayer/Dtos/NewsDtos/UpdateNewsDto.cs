using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.NewsDtos
{
    public class UpdateNewsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? AiSource { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<Guid> SelectedTagIds { get; set; } = new();
        public List<Guid> SelectedCategoryIds { get; set; } = new();

       
        public List<string> AllTags { get; set; } = new();
        public List<string> AllCategories { get; set; } = new();
    }
}
