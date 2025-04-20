using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();    
        public ICollection<News> NewsList { get; set; } = new List<News>();

        //kendi içinde alt kategorilere sahip olabiliyor
        //kendi kendine referans alan bir yapı oluşturduk.
        //Gevşek bağlı (loosely coupled) ve genişletilebilir olması için List<T> yerine ICollection<T> tercih edilir.
    }
}
