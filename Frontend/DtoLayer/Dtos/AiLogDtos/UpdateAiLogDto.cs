using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AiLogDtos
{
    public class UpdateAiLogDto
    {

        public Guid Id { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string? SourceModel { get; set; }
        public bool? IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime? UpdatedTime { get; set; }

    }
}
