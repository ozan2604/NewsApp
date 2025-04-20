using Domain.Entities;
using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AiLogDtos
{
    public class CreateAiLogDto : BaseDto
    {
        public string Prompt { get; set; }
        public string SourceModel { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }
        public string Response { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }


    }
}
