using Application.Repositories.NewsRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommandRequest, CreateNewsCommandResponse>
    {
        private readonly IWriteNewsRepository _writeNewsRepository;

        public CreateNewsCommandHandler(IWriteNewsRepository writeNewsRepository)
        {
            _writeNewsRepository = writeNewsRepository;
        }

        public async Task<CreateNewsCommandResponse> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
           await _writeNewsRepository.AddAsync(new News()
           {
               Title = request.Title,
               Content = request.Content,
               CreatedTime = DateTime.UtcNow,
               UpdatedTime = DateTime.UtcNow,
               AiSource = request.AiSource,
               AuthorId = request.AuthorId,
               PublishedAt = request.PublishedAt,
               IsAIGenerated = request.IsAIGenerated,
               ImageUrl = request.ImageUrl


           });
            await _writeNewsRepository.SaveAsync();
            return new CreateNewsCommandResponse()
            {
                Message = "News Created Successfully"
            };
        }
    }
}
