using Application.Features.Mediatr.NewsQueries.GetByIdNews;
using Application.Features.Mediatr.TagQueries.GetByIdTag;
using Application.Repositories.AiLogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsQueries.GetByIDAiLogs
{
    public class GetByIDAiLogsQueryHandler : IRequestHandler<GetByIDAiLogsQueryRequest, GetByIDAiLogsQueryResponse>
    {
        private readonly IReadAiLogRepository _aiLogReadRepo;

        public GetByIDAiLogsQueryHandler(IReadAiLogRepository aiLogReadRepo)
        {
            _aiLogReadRepo = aiLogReadRepo;
        }

        public async Task<GetByIDAiLogsQueryResponse> Handle(GetByIDAiLogsQueryRequest request, CancellationToken cancellationToken)
        {
            var ailogs = await _aiLogReadRepo.GetByIdAsync(request.Id);

            var result = new  GetByIDAiLogsQueryResponse
            {
                Id = ailogs.Id,
                Prompt = ailogs.Prompt,
                Response = ailogs.Response,
                SourceModel = ailogs.SourceModel,
                IsSuccessful = ailogs.IsSuccessful,
                ErrorMessage = ailogs.ErrorMessage,
                UpdatedTime = DateTime.UtcNow,
            };

            return result;
        }
    }
}
