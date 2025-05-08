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

namespace Application.Features.Mediatr.NewsCommands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommandRequest, UpdateNewsCommandResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;
        private readonly IWriteNewsRepository _writeNewsRepository;
        private readonly IReadTagRepository _readTagRepository;
        private readonly IReadCateagoryRepository _readCategoryRepository;

        public UpdateNewsCommandHandler(IReadNewsRepository readNewsRepository, IWriteNewsRepository writeNewsRepository, IReadTagRepository readTagRepository, IReadCateagoryRepository readCategoryRepository)
        {
            _readNewsRepository = readNewsRepository;
            _writeNewsRepository = writeNewsRepository;
            _readTagRepository = readTagRepository;
            _readCategoryRepository = readCategoryRepository;
        }

       
           public async Task<UpdateNewsCommandResponse> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var news = await _readNewsRepository.GetByIdAsync(request.Id);
            if (news == null)
                throw new Exception("News not found");

            news.Title = request.Title;
            news.Content = request.Content;
            news.UpdatedTime = DateTime.UtcNow;
            news.PublishedAt = request.PublishedAt;
            news.ImageUrl = request.ImageUrl;
            news.AiSource = request.AiSource;

            // Null koruması
            request.SelectedTagIds ??= new List<Guid>();
            request.SelectedCategoryIds ??= new List<Guid>();

            // Kategoriler
            news.Categorires.Clear();
            var categories = await _readCategoryRepository
                .GetWhere(x => request.SelectedCategoryIds.Contains(x.Id))
                .ToListAsync(cancellationToken);
            foreach (var category in categories)
                news.Categorires.Add(category);

            // Etiketler
            news.Tags.Clear();
            var tags = await _readTagRepository
                .GetWhere(x => request.SelectedTagIds.Contains(x.Id))
                .ToListAsync(cancellationToken);
            foreach (var tag in tags)
                news.Tags.Add(tag);

            await _writeNewsRepository.SaveAsync();

            return new UpdateNewsCommandResponse
            {
                Message = "News Updated Successfully"
            };
        }
    }
}
