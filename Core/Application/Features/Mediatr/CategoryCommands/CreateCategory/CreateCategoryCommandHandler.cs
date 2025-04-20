using Application.Repositories;
using Application.Repositories.CategoryRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly IWriteCategoryRepository _categoryWriteRepo;

        public CreateCategoryCommandHandler(IWriteCategoryRepository categoryWriteRepo)
        {
            _categoryWriteRepo = categoryWriteRepo;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                ParentCategoryId = request.ParentCategoryId,
                Image = request.Image,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,

            };

            await _categoryWriteRepo.AddAsync(category);
            await _categoryWriteRepo.SaveAsync();

            return new CreateCategoryCommandResponse
            {
                Category = category,
                Message = "Category created successfully"
            };
        }
    }
}

