using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagCommands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommandRequest, UpdateTagCommandResponse>
    {
        private readonly IReadTagRepository _readTagRepository;
        private readonly IWriteTagRepository _writeTagRepository;

        public UpdateTagCommandHandler(IReadTagRepository readTagRepository, IWriteTagRepository writeTagRepository)
        {
            _readTagRepository = readTagRepository;
            _writeTagRepository = writeTagRepository;
        }

        public async Task<UpdateTagCommandResponse> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
        {
            Tag tag = await _readTagRepository.GetByIdAsync(request.Id);
            tag.Name = request.Name;
            tag.UpdatedTime = DateTime.UtcNow;
            tag.CreatedTime = DateTime.UtcNow;




            await _writeTagRepository.SaveAsync();
            return new UpdateTagCommandResponse()
            {
                Message = "Tag Updated Successfully"
            };
        }
    }
}
