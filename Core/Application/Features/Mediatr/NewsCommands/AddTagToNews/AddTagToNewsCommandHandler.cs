using Application.Repositories.NewsRepository;
using Application.Repositories.TagRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.AddTagToNews
{
    public class AddTagToNewsCommandHandler : IRequestHandler<AddTagToNewsCommandRequest, AddTagToNewsCommandResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;
        private readonly IWriteNewsRepository _writeNewsRepository;
        private readonly IReadTagRepository _readTagRepository;

        public AddTagToNewsCommandHandler(IReadNewsRepository readNewsRepository, IWriteNewsRepository writeNewsRepository, IReadTagRepository readTagRepository)
        {
            _readNewsRepository = readNewsRepository;
            _writeNewsRepository = writeNewsRepository;
            _readTagRepository = readTagRepository;
        }
        public async Task<AddTagToNewsCommandResponse> Handle(AddTagToNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var news = await _readNewsRepository
           .GetWhere(n => n.Id == request.NewsId)
           .Include(n => n.Tags)
           .FirstOrDefaultAsync(cancellationToken);

            if (news == null)
                throw new Exception("News not found.");

            var tag = await _readTagRepository.GetByIdAsync(request.TagId);
            if (tag == null)
                throw new Exception("Tag not found.");

            if (!news.Tags.Any(t => t.Id == tag.Id))
            {
                news.Tags.Add(tag);
                await _writeNewsRepository.SaveAsync();
            }

            return new AddTagToNewsCommandResponse { Message = "Tag added to news successfully." };
        }
    }
    }
    
    

