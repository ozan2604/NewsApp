using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandResponse
    {
        public string Message { get; set; }
        public Category? Category { get; set; }
    }
}
