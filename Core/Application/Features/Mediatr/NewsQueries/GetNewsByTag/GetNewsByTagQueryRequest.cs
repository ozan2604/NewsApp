﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetNewsByTag
{
    public class GetNewsByTagQueryRequest : IRequest<List<GetNewsByTagQueryResponse>>
    {
        public string TagName { get; set; }
    }
}
