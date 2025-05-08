using Application.Features.Mediatr.CategoryQueries.GetAllCategory;
using Application.Repositories.AiLogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AiLogsQueries.GetAllAiLogs
{
    public class GetAiLogsQueryHandler : IRequestHandler<GetAiLogsQueryRequest, List<GetAiLogsQueryResponse>>
    {
        private readonly IReadAiLogRepository _readAiLogRepository;

        public GetAiLogsQueryHandler(IReadAiLogRepository readAiLogRepository)
        {
            _readAiLogRepository = readAiLogRepository;
        }

        public async Task<List<GetAiLogsQueryResponse>> Handle(GetAiLogsQueryRequest request, CancellationToken cancellationToken)
        {
            var logs = _readAiLogRepository.GetAll().ToList();
            var result = logs.Select(log => new GetAiLogsQueryResponse
            {
                Id = log.Id,
                Prompt = log.Prompt,
                Response = log.Response,
                SourceModel = log.SourceModel,
                IsSuccessful = log.IsSuccessful,
                ErrorMessage = log.ErrorMessage,
                CreatedTime = log.CreatedTime,
                UpdatedTime = log.UpdatedTime
            }).ToList();

            return result;
            // return await Task.FromResult(result);
        }
    }
}
