using Application.Features.Mediatr.AiLogsCommands.CreateAiLogsCommand;
using Application.Repositories.AiLogRepository;
using Application.Repositories.NewsRepository;
using Application.Services;
using Domain.Entities;
using MediatR;

public class CreateAilogsCommandHandler : IRequestHandler<CreateAilogsCommandRequest, CreateAiLogsCommandResponse>
{
    private readonly IWriteAiLogRepository _aiLogRepository;
    private readonly IWriteNewsRepository _newsRepository; 
    private readonly IAIService _aiService;

    public CreateAilogsCommandHandler(IWriteAiLogRepository aiLogRepository, IWriteNewsRepository newsRepository, IAIService aiService)
    {
        _aiLogRepository = aiLogRepository;
        _newsRepository = newsRepository;
        _aiService = aiService;
    }

    public async Task<CreateAiLogsCommandResponse> Handle(CreateAilogsCommandRequest request, CancellationToken cancellationToken)
    {
        
        var aiResponse = await _aiService.GetResponseAsync(request.Prompt, request.SourceModel);

       
        var news = new News
        {
            Id = Guid.NewGuid(),
            Title = request.Prompt.Length > 50 ? request.Prompt.Substring(0, 50) + "..." : request.Prompt,
            Content = aiResponse,
            PublishedAt = DateTime.UtcNow,
            IsAIGenerated = true,
            AiSource = request.SourceModel,
            ImageUrl = "default.png" ,
            CreatedTime = DateTime.UtcNow
            
        };

        await _newsRepository.AddAsync(news);

        
        var entity = new AiLog
        {
            Id = Guid.NewGuid(),
            Prompt = request.Prompt,
            Response = aiResponse,
            SourceModel = request.SourceModel,
            NewsId = news.Id,
            IsSuccessful = true,
            CreatedTime = DateTime.UtcNow,
            UpdatedTime = DateTime.UtcNow
        };

        await _aiLogRepository.AddAsync(entity);

        
        await _aiLogRepository.SaveAsync();
        await _newsRepository.SaveAsync();

        return new CreateAiLogsCommandResponse
        {
            Id = entity.Id,
            Prompt = entity.Prompt,
            Response = entity.Response,
            SourceModel = entity.SourceModel,
            IsSuccessful = entity.IsSuccessful,
            CreatedTime = DateTime.UtcNow,
            UpdatedTime = DateTime.UtcNow,

        };
    }
}
