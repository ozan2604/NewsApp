using Application.Repositories.AppRoleRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AppRoleRepository
{
    internal class AppRoleRepository : ReadRepository<AppRole> , IAppRoleRepository
    {
        private readonly NewsAppDbContext _context;

        
        public AppRoleRepository(NewsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<AppRole> Table => _context.Set<AppRole>();

        public async Task<List<AppRole>> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            return await Table.Where(filter).ToListAsync();
        }
    }
   
}
