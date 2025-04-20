using Application.Repositories.NewsRepository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.NewsRepository
{
    public class ReadNewsRepository : ReadRepository<News> , IReadNewsRepository
    {
        public ReadNewsRepository(NewsAppDbContext context) : base(context)
        {
        }
    }
}
