using Application.Repositories;
using Application.Repositories.CategoryRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryQueries.GetByIdCategory
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly IReadCateagoryRepository _categoryReadRepo;

        public GetCategoryByIdQueryHandler(IReadCateagoryRepository categoryReadRepo)
        {
            _categoryReadRepo = categoryReadRepo;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepo.GetByIdAsync(request.Id);

            return new GetCategoryByIdQueryResponse
            {
                Category = category
            };
        }
    }
}
