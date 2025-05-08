using Application.Features.Mediatr.NewsCommands.RemoveNews;
using Application.Features.Mediatr.TagCommands.RemoveTag;
using Application.Repositories.AiLogRepository;
using Application.Repositories.NewsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsCommands.RemoveAiLogsCommand
{
    public class RemoveAiLogCommandHandler : IRequestHandler<RemoveAiLogsCommandRequest, RemoveAiLogsCommandResponse>
    {
        private readonly IWriteAiLogRepository _aiLogWriteRepository;
        private readonly IReadAiLogRepository _aiLogReadRepository;

        public RemoveAiLogCommandHandler(IWriteAiLogRepository aiLogWriteRepository, IReadAiLogRepository aiLogReadRepository)
        {
            _aiLogWriteRepository = aiLogWriteRepository;
            _aiLogReadRepository = aiLogReadRepository;
        }

        public async Task<RemoveAiLogsCommandResponse> Handle(RemoveAiLogsCommandRequest request, CancellationToken cancellationToken)
        {
            var ailogs = await _aiLogReadRepository.GetByIdAsync(request.Id, false);

            _aiLogWriteRepository.Remove(ailogs);
            await _aiLogWriteRepository.SaveAsync();

            return new RemoveAiLogsCommandResponse()
            {
                Message = "AiLogs removed successfully."
            };

        }
    }
}
