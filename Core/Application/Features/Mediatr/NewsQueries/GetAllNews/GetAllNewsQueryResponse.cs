using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetAllNews
{
    public class GetAllNewsQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string? AiSource { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public List<string> TagNames { get; set; } = new();
        public List<string> CategoryNames { get; set; } = new();

    }
}
