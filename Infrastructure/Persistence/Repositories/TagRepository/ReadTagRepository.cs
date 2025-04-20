using Application.Repositories.TagRepository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.TagRepository
{
    public class ReadTagRepository : ReadRepository<Tag>, IReadTagRepository
    {
        public ReadTagRepository(NewsAppDbContext context) : base(context)
        {
        }
    }
}
