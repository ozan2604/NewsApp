using Application.Repositories;
using Application.Repositories.AppUserRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AppUserRepository
{
    public class AppUserRepository : WriteRepository<AppUser>, IAppUserRepository
    {
        private readonly NewsAppDbContext _context;
        public AppUserRepository(NewsAppDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<AppUser> Table => _context.Set<AppUser>();

        

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _context.Set<AppUser>().FirstOrDefaultAsync(filter);
        }

        
    }
    
}
