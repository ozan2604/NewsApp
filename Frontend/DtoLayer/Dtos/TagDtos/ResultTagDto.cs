using Domain.Entities;
using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.TagDtos
{
    public class ResultTagDto : BaseDto
    {
        public string Name { get; set; }
        public ICollection<News> News { get; set; }

    }
}
