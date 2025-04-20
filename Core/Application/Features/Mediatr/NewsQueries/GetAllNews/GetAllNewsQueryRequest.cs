using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetAllNews
{
    public class GetAllNewsQueryRequest : IRequest<GetAllNewsQueryResponse>
    {
        public bool OnlyAIGenerated { get; set; } //filtremiz (istersen tüm hepsini listele istersen sadece AI olanları listele)
    }
}
