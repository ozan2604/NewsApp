using Application.Repositories.CategoryRepository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category> , IWriteCategoryRepository
    {
        public CategoryWriteRepository(NewsAppDbContext context) : base(context)
        {
        }
    }
  
}
