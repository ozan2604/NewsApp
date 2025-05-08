using Application.Repositories.CategoryRepository;
using Application.Repositories.NewsRepository;
using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetByIdNews
{
    public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQueryRequest, GetByIdNewsQueryResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;
        private readonly IReadTagRepository _readTagRepository;
        private readonly IReadCateagoryRepository _readCategoryRepository;

        public GetByIdNewsQueryHandler(
            IReadNewsRepository readNewsRepository,
            IReadTagRepository readTagRepository,
            IReadCateagoryRepository readCategoryRepository)
        {
            _readNewsRepository = readNewsRepository;
            _readTagRepository = readTagRepository;
            _readCategoryRepository = readCategoryRepository;
        }

        public async Task<GetByIdNewsQueryResponse> Handle(GetByIdNewsQueryRequest request, CancellationToken cancellationToken)
        {
            var news = await _readNewsRepository
                .GetWhere(x => x.Id == request.Id)
                .Include(x => x.Tags)
                .Include(x => x.Categorires)
                .FirstOrDefaultAsync(cancellationToken);

            if (news == null)
                throw new Exception($"News not found with id: {request.Id}");

            var allTags = await _readTagRepository.GetAll().ToListAsync(cancellationToken);
            var allCategories = await _readCategoryRepository.GetAll().ToListAsync(cancellationToken);

            return new GetByIdNewsQueryResponse
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                PublishedAt = news.PublishedAt,
                ImageUrl = news.ImageUrl,
                AiSource = news.AiSource,
                SelectedTagIds = news.Tags.Select(t => t.Id).ToList(),
                SelectedCategoryIds = news.Categorires.Select(c => c.Id).ToList(),

                AllTags = allTags
                    .Select(t => $"{t.Id}|{t.Name}")
                    .ToList(),

                AllCategories = allCategories
                     .Select(c => $"{c.Id}|{c.Name}")
                       .ToList()
            };

        }
    }

}
