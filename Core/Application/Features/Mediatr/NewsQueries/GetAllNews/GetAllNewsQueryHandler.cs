using Application.Features.Mediatr.NewsQueries.GetAllNews;
using Application.Features.Mediatr.TagQueries.GetAllTag;
using Application.Repositories.NewsRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQueryRequest, List<GetAllNewsQueryResponse>>
{
    private readonly IReadNewsRepository _readNewsRepository;

    public GetAllNewsQueryHandler(IReadNewsRepository readNewsRepository)
    {
        _readNewsRepository = readNewsRepository;
    }

    public async Task<List<GetAllNewsQueryResponse>> Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
    {
        var newsList = await _readNewsRepository.GetAll(false)
            .Include(n => n.Tags)
            .Include(n => n.Categorires)
            .ToListAsync(cancellationToken);

        return newsList.Select(news => new GetAllNewsQueryResponse
        {
            Id = news.Id,
            Title = news.Title,
            Content = news.Content,
            ImageUrl = news.ImageUrl,
            AiSource = news.AiSource,
            PublishedAt = news.PublishedAt,
            CreatedTime = news.CreatedTime,
            UpdatedTime = news.UpdatedTime,
            TagNames = news.Tags.Select(t => t.Name).ToList(),
            CategoryNames = news.Categorires.Select(c => c.Name).ToList()
        }).ToList();
    }
}
