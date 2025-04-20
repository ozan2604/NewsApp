using Application.Repositories.TagRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagCommands.RemoveTag
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommandRequest, RemoveTagCommandResponse>
    {
        private readonly IReadTagRepository _tagReadRepository;
        private readonly IWriteTagRepository _tagWriteRepository;

        public RemoveTagCommandHandler(IReadTagRepository tagReadRepository, IWriteTagRepository tagWriteRepository)
        {
            _tagReadRepository = tagReadRepository;
            _tagWriteRepository = tagWriteRepository;
        }

        public async Task<RemoveTagCommandResponse> Handle(RemoveTagCommandRequest request, CancellationToken cancellationToken)
        {
            var tag = await _tagReadRepository.GetByIdAsync(request.Id, false);

            _tagWriteRepository.Remove(tag);
            await _tagWriteRepository.SaveAsync();

            return new RemoveTagCommandResponse()
            {
                Message = "Tag removed successfully."
            };
        }
    }
    
}
