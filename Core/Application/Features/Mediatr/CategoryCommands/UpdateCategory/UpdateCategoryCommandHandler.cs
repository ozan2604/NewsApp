using Application.Repositories.CategoryRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest , UpdateCategoryCommandResponse>
    {
        private readonly IWriteCategoryRepository _categoryWriteRepo;
        private readonly IReadCateagoryRepository _categoryReadRepo;

        public UpdateCategoryCommandHandler(IWriteCategoryRepository categoryWriteRepo, IReadCateagoryRepository categoryReadRepo)
        {
            _categoryWriteRepo = categoryWriteRepo;
            _categoryReadRepo = categoryReadRepo;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryReadRepo.GetByIdAsync(request.Id);
            

            category.Name = request.Name;
            category.Image = request.Image;
            category.ParentCategoryId = request.ParentCategoryId;
            category.UpdatedTime = DateTime.UtcNow;

            await _categoryWriteRepo.SaveAsync();

            return new UpdateCategoryCommandResponse();
        }
    }
}
