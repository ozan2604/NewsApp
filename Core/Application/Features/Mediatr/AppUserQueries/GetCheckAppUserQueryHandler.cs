using Application.Repositories;
using Application.Repositories.AppRoleRepository;
using Application.Repositories.AppUserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserQueries
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQueryRequest, GetCheckAppUserQueryResponse>
    {
      
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResponse> Handle(GetCheckAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResponse();

            
            var user = await _appUserRepository.GetByFilterAsync(x =>
                x.Username == request.Username && x.Password == request.Password);


            if (user is null)
            {
                values.IsExist = false;
                return values;
            }

            
            var roleList = await _appRoleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
            var role = roleList.FirstOrDefault();

            values.IsExist = true;
            values.Username = user.Username;
            values.Id = user.Id;
            values.Role = role?.AppRoleName;

            return values;
        }
    }
}
