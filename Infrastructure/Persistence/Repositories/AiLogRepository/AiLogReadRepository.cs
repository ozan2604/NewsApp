using Application.Repositories;
using Application.Repositories.AiLogRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AiLogRepository
{
    public class AiLogReadRepository : ReadRepository<AiLog>, IReadAiLogRepository
    {
        public AiLogReadRepository(NewsAppDbContext context) : base(context)
        {
        }
    }

}
