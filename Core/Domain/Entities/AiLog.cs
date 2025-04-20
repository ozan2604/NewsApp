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
        public string Prompt { get; set; } = string.Empty; // AI'a ne sorduk
        public string Response { get; set; } = string.Empty; // AI'dan ne döndü

        public string? SourceModel { get; set; } // Örn: GPT-4, Gemini, Claude
        public bool IsSuccessful { get; set; } = true;
        public string? ErrorMessage { get; set; } 

        
        public Guid? NewsId { get; set; }
        public News? News { get; set; }
    }
}
