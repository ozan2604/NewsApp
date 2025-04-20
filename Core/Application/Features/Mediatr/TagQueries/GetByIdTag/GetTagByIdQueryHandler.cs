using Application.Repositories;
using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagQueries.GetByIdTag
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQueryRequest, GetTagByIdQueryResponse>
    {

        private readonly IReadTagRepository _tagReadRepo;

        public GetTagByIdQueryHandler(IReadTagRepository tagReadRepo)
        {
            _tagReadRepo = tagReadRepo;
        }

        public async Task<GetTagByIdQueryResponse> Handle(GetTagByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var tag = await _tagReadRepo.GetByIdAsync(request.Id);

            return new GetTagByIdQueryResponse
            {
                Tag = tag
            };
        }
    }
}
