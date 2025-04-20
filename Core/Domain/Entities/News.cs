using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; } // haber ne zaman yayınlandı. planlı yayınlar için
        public bool IsAIGenerated { get; set; } = false; // AI tarafından üretilip üretilmediği
        public string? AiSource { get; set; }

        public string ImageUrl { get; set; }


        // Author (nullable olabilir çünkü AI haberlerinde olmayabilir)
        public Guid? AuthorId { get; set; }
        public AppUser? Author { get; set; }

        public ICollection<Category> Categorires { get; set; } = new List<Category>();
        public ICollection<Tag> Tags { get; set; }  = new List<Tag>();
        public ICollection<AiLog> AiLogs { get; set; } = new List<AiLog>();
    }
}
