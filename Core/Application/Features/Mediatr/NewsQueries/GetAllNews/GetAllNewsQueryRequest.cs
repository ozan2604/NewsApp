﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.NewsQueries.GetAllNews
{
    public class GetAllNewsQueryRequest : IRequest<List<GetAllNewsQueryResponse>>
    {
        
    }
}
