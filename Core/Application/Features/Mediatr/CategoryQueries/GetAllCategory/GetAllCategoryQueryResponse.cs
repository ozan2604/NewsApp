using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public List<Category> Categories { get; set; }
    }
}
