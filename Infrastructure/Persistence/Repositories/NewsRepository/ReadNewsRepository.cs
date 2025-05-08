using Application.Repositories.NewsRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly NewsAppDbContext _context;

        public ReadNewsRepository(NewsAppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<News>> GetNewsByTagAsync(string tagName)
        {
            return await _context.News
                .Where(n => n.Tags.Any(t => t.Name.ToLower() == tagName.ToLower()))
                .ToListAsync();
        }
    }
}
