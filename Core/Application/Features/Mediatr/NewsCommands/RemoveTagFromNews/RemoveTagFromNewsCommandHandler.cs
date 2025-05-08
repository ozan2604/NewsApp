using Application.Repositories.NewsRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.RemoveTagFromNews
{
    public class RemoveTagFromNewsCommandHandler : IRequestHandler<RemoveTagFromNewsCommandRequest, RemoveTagFromNewsCommandResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;
        private readonly IWriteNewsRepository _writeNewsRepository;

        public RemoveTagFromNewsCommandHandler(IReadNewsRepository readNewsRepository, IWriteNewsRepository writeNewsRepository)
        {
            _readNewsRepository = readNewsRepository;
            _writeNewsRepository = writeNewsRepository;
        }

        public async Task<RemoveTagFromNewsCommandResponse> Handle(RemoveTagFromNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var news = await _readNewsRepository
                .GetWhere(n => n.Id == request.NewsId)
                .Include(n => n.Tags)
                .FirstOrDefaultAsync(cancellationToken);

            if (news == null)
                throw new Exception("News not found.");

            var tagToRemove = news.Tags.FirstOrDefault(t => t.Id == request.TagId);
            if (tagToRemove != null)
            {
                news.Tags.Remove(tagToRemove);
                await _writeNewsRepository.SaveAsync();
            }

            return new RemoveTagFromNewsCommandResponse { Message = "Tag removed from news successfully." };
        }
    }
}
