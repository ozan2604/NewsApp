using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AiLogDtos
{
    public class ResultAiLogDto : BaseDto
    {
        public string Prompt { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public string? SourceModel { get; set; }
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }

        public Guid? NewsId { get; set; }
        public string? NewsTitle { get; set; } // İsteğe bağlı
    }
}
