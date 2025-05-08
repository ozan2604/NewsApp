using Application.Repositories.AiLogRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsCommands.UpdateAiLogsCommand
{
    public class UpdateAiLogsCommandHandler : IRequestHandler<UpdateAiLogsCommandRequest, UpdateAiLogsCommandResponse>
    {
        private readonly IReadAiLogRepository _readAiLogRepository;
        private readonly IWriteAiLogRepository _writeAiLogRepository;

        public UpdateAiLogsCommandHandler(IReadAiLogRepository readAiLogRepository, IWriteAiLogRepository writeAiLogRepository)
        {
            _readAiLogRepository = readAiLogRepository;
            _writeAiLogRepository = writeAiLogRepository;
        }
        public async Task<UpdateAiLogsCommandResponse> Handle(UpdateAiLogsCommandRequest request, CancellationToken cancellationToken)
        {
            AiLog aiLog = await _readAiLogRepository.GetByIdAsync(request.Id);
            aiLog.Prompt = request.Prompt;
            aiLog.Response = request.Response;
            aiLog.SourceModel = request.SourceModel;
            aiLog.IsSuccessful = request.IsSuccessful;
            aiLog.ErrorMessage = request.ErrorMessage;
            aiLog.UpdatedTime = DateTime.UtcNow;

             await _writeAiLogRepository.SaveAsync();
            return new UpdateAiLogsCommandResponse()
            {
                Message = "AiLog Updated Successfully"
            };

        }
    }
}
