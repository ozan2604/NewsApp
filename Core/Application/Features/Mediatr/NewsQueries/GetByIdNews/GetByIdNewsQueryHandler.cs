using Application.Repositories.NewsRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetByIdNews
{
    public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQueryRequest, GetByIdNewsQueryResponse>
    {
        private readonly IReadNewsRepository _readNewsRepository;

        public GetByIdNewsQueryHandler(IReadNewsRepository readNewsRepository)
        {
            _readNewsRepository = readNewsRepository;
        }

        public async Task<GetByIdNewsQueryResponse> Handle(GetByIdNewsQueryRequest request, CancellationToken cancellationToken)
        {
            News news = await _readNewsRepository.GetByIdAsync(request.Id, false); 

            return new GetByIdNewsQueryResponse()
            {
                News = news
            };
        }
    }
}
