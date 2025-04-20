﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserQueries
{
    public class GetCheckAppUserQueryRequest : IRequest<GetCheckAppUserQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
