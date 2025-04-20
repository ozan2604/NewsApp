using Application.Repositories.NewsRepository;
using Domain.Entities;
using MediatR;
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

        public UpdateNewsCommandHandler(IReadNewsRepository readNewsRepository, IWriteNewsRepository writeNewsRepository)
        {
            _readNewsRepository = readNewsRepository;
            _writeNewsRepository = writeNewsRepository;
        }

        public async Task<UpdateNewsCommandResponse> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            News news = await _readNewsRepository.GetByIdAsync(request.Id);
            news.Title = request.Title;
            news.Content = request.Content;
            news.UpdatedTime = DateTime.UtcNow;
            news.PublishedAt = request.PublishedAt;
            news.ImageUrl = request.ImageUrl;
            news.AiSource = request.AiSource;
            news.AuthorId = request.AuthorId;
            news.CreatedTime = request.CreatedDate;
            news.IsAIGenerated = request.IsAIGenerated;


            //if(request.Categorires != null)
            //{
            //    news.Categorires.Clear();
            //    foreach (var category in request.Categorires)
            //    {
            //        news.Categorires.Add(category);
            //    }
            //}

            //if (request.Tags != null)
            //{
            //    news.Tags.Clear();
            //    foreach (var tag in request.Tags)
            //    {
            //        news.Tags.Add(tag);
            //    }
            //}

            //if(request.AiLogs != null)
            //{
            //    news.AiLogs.Clear();
            //    foreach (var aiLog in request.AiLogs)
            //    {
            //        news.AiLogs.Add(aiLog);
            //    }
            //}

            await _writeNewsRepository.SaveAsync();
            return new UpdateNewsCommandResponse()
            {
                Message = "News Updated Successfully"
            };
        }
    }
}
