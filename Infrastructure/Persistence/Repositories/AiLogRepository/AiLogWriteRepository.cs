using Application.Repositories.AiLogRepository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AiLogRepository
{
    public class AiLogWriteRepository : WriteRepository<AiLog> , IWriteAiLogRepository
    {
        public AiLogWriteRepository(NewsAppDbContext context) : base(context)
        {
        }
    }
    
}
