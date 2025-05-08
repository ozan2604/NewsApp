using Application.Repositories.AppUserRepository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AppUserRepository
{
    public class ReadAppUserRepository : ReadRepository<AppUser>, IReadAppUserRepository
    {
        public ReadAppUserRepository(NewsAppDbContext context) : base(context)
        {
        }
    }
}
