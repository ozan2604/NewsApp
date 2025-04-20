using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.AppRoleRepository
{
    public interface IAppRoleRepository : IReadRepository<AppRole>
    {
        Task<List<AppRole>> GetByFilterAsync(Expression<Func<AppRole, bool>> filter);
    }
}
