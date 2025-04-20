using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.NewsRepository
{
    public interface IWriteNewsRepository : IWriteRepository<News>
    {
    }
}
