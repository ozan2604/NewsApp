using Domain.Entities;
using DtoLayer.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.CategoryDtos
{
    public class CreateCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string? ParentCategoryIdAsString { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<News> NewsList { get; set; } = new List<News>();
    }
}
