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
    public class AiLogRepository : WriteRepository<AiLog> , IAiLogRepository
    {
        private readonly NewsAppDbContext _context;
        public AiLogRepository(NewsAppDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<AiLog> AddAsync(AiLog log)
        //{
        //    await _context.AiLogs.AddAsync(log);
        //    return log;
        //}
    }
    
}
