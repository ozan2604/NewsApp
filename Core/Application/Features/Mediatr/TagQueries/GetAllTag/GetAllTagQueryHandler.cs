using Application.Repositories;
using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.TagQueries.GetAllTag
{
    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQueryRequest, GetAllTagQueryResponse>
    {
        private readonly IReadTagRepository _tagReadRepo;

        public GetAllTagQueryHandler(IReadTagRepository tagReadRepo)
        {
            _tagReadRepo = tagReadRepo;
        }

        public async Task<GetAllTagQueryResponse> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _tagReadRepo.GetAll(false).ToListAsync(cancellationToken);

            return new GetAllTagQueryResponse
            {
                Tags = list
            };
        }
    }
}
