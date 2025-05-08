using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetNewsByTag
{
    public class GetNewsByTagQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public string ImageUrl { get; set; }
        public string? AiSource { get; set; }
    }
}
