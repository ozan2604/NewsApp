using Application.Repositories.NewsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsCommands.RemoveNews
{
    public class RemoveNewsCommandHandler : IRequestHandler<RemoveNewsCommandRequest, RemoveNewsCommandResponse>
    {
        private readonly IWriteNewsRepository _writeNewsRepository;
        private readonly IReadNewsRepository _readNewsRepository;
        public RemoveNewsCommandHandler(IWriteNewsRepository writeNewsRepository, IReadNewsRepository readNewsRepository)
        {
            _writeNewsRepository = writeNewsRepository;
            _readNewsRepository = readNewsRepository;
        }
        public async Task<RemoveNewsCommandResponse> Handle(RemoveNewsCommandRequest request, CancellationToken cancellationToken)
        {
            
            await _writeNewsRepository.RemoveAsync(request.Id);
            await _writeNewsRepository.SaveAsync();
            return new RemoveNewsCommandResponse
            {
                Message = "News Removed Successfully"
            };
        }
    }
    
}
