using Application.Repositories.NewsRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQueryRequest, GetAllNewsQueryResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;

        public GetAllNewsQueryHandler(IReadNewsRepository readNewsRepository)
        {
            _readNewsRepository = readNewsRepository;
        }

        public async Task<GetAllNewsQueryResponse> Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
        {
            var query =  _readNewsRepository.GetAll(false);
            if (request.OnlyAIGenerated == true)
                query = query.Where(x => x.IsAIGenerated);

            var result = await query.ToListAsync(cancellationToken);

            return new GetAllNewsQueryResponse()
            {
                NewsList = result
            };
        }
    }
}
