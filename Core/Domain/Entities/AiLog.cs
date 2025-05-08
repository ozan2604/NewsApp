using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AiLog : BaseEntity
    {
        public string Prompt { get; set; }
        public string Response { get; set; }

        public string? SourceModel { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string? ErrorMessage { get; set; }

        
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; } = DateTime.Now;

        public Guid? AuthorId { get; set; }
        public AppUser? Author { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();


        //şuanlık senaryo dışı
        public Guid? NewsId { get; set; }
        public News? News { get; set; }
    }
}
