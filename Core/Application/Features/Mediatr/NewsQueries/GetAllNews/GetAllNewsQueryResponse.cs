using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetAllNews
{
    public class GetAllNewsQueryResponse
    {
        public List<News> NewsList { get; set; }
    }
}
