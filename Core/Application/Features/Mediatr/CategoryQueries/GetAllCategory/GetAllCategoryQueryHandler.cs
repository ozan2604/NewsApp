using Application.Repositories;
using Application.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly IReadCateagoryRepository _categoryRepo;

        public GetAllCategoryQueryHandler(IReadCateagoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepo.GetAll(false).ToListAsync(cancellationToken);

            return new GetAllCategoryQueryResponse
            {
                Categories = result
            };
        }
    }
}
