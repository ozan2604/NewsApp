using Application.Repositories.NewsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetNewsByTag
{
    public class GetNewsByTagQueryHandler : IRequestHandler<GetNewsByTagQueryRequest, List<GetNewsByTagQueryResponse>>
    {
        private readonly IReadNewsRepository _newsRepository;

        public GetNewsByTagQueryHandler(IReadNewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<GetNewsByTagQueryResponse>> Handle(GetNewsByTagQueryRequest request, CancellationToken cancellationToken)
        {
            var newsList = await _newsRepository.GetNewsByTagAsync(request.TagName);

            return newsList.Select(n => new GetNewsByTagQueryResponse
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                PublishedAt = n.PublishedAt,
                ImageUrl = n.ImageUrl,
                AiSource = n.AiSource

            }).ToList();
        }
    }
}
