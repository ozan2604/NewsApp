using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagCommands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
    {
        private readonly IWriteTagRepository _writeTagRepository;

        public CreateTagCommandHandler(IWriteTagRepository writeTagRepository)
        {
            _writeTagRepository = writeTagRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeTagRepository.AddAsync(new Tag
            {
                Name = request.Name,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,
            });

            await _writeTagRepository.SaveAsync();
            return new CreateTagCommandResponse
            {
               
                Message = "Tag created successfully"
            };
        }
    }
    
}
