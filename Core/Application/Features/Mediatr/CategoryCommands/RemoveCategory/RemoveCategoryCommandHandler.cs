using Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryCommands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        private readonly IWriteCategoryRepository _categoryWriteRepo;
        private readonly IReadCateagoryRepository _categoryReadRepo;

        public RemoveCategoryCommandHandler(IWriteCategoryRepository categoryWriteRepo, IReadCateagoryRepository categoryReadRepo)
        {
            _categoryWriteRepo = categoryWriteRepo;
            _categoryReadRepo = categoryReadRepo;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await  _categoryReadRepo.GetByIdAsync(request.Id, false);   
            
            await _categoryWriteRepo.SaveAsync();

            return new RemoveCategoryCommandResponse()
            {
                
                Message = "Category removed successfully"
            };
        }
    }
    
    
}
