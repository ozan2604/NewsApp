using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AiLog> AiLogs { get; set; } = new List<AiLog>();
        public ICollection<News> News { get; set; } = new List<News>();
    }
}
