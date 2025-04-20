using Application.Repositories;
using Application.Repositories.AiLogRepository;
using Application.Services;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogCommands.CreateAiLogCommands
{
    public class CreateAilogCommandHandler : IRequestHandler<CreateAilogCommandRequest, CreateAiLogCommandResponse>
    {
        private readonly IAiLogRepository _aiLogRepository;
        private readonly IAIService _aiService;

        public CreateAilogCommandHandler(IAiLogRepository aiLogRepository, IAIService aiService)
        {
            _aiLogRepository = aiLogRepository;
            _aiService = aiService;
        }

        public async Task<CreateAiLogCommandResponse> Handle(CreateAilogCommandRequest request, CancellationToken cancellationToken)
        {
            var aiResponse = await _aiService.GetResponseAsync(request.Prompt, request.SourceModel);

            // Ailog entity'sini oluştur
            var entity = new AiLog
            {
                Id = Guid.NewGuid(),
                Prompt = request.Prompt,
                Response = aiResponse,
                SourceModel = request.SourceModel,
                NewsId = request.NewsId,
                IsSuccessful = true
            };

            
            await _aiLogRepository.AddAsync(entity);
            await _aiLogRepository.SaveAsync();

            // Geri dön
            return new CreateAiLogCommandResponse
            {
                Id = entity.Id,
                Prompt = entity.Prompt,
                Response = entity.Response,
                SourceModel = entity.SourceModel,
                IsSuccessful = entity.IsSuccessful,
                
            };
        }
    }
    

}
