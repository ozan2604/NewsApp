using Application.Repositories.AppRoleRepository;
using Application.Repositories.AppUserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserQueries.GetByIdAppUser
{
    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQueryRequest, GetByIdAppUserQueryResponse>
    {
        private readonly IReadAppUserRepository _readappUserRepository;
        private readonly IAppRoleRepository _appRoleRepo;

        public GetByIdAppUserQueryHandler(IReadAppUserRepository readappUserRepository, IAppRoleRepository appRoleRepo)
        {
            _readappUserRepository = readappUserRepository;
            _appRoleRepo = appRoleRepo;
        }

        public async Task<GetByIdAppUserQueryResponse> Handle(GetByIdAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _readappUserRepository.GetByIdAsync(request.Id);
            var role = await _appRoleRepo.GetByIdAsync(appUser.AppRoleId);

            return new GetByIdAppUserQueryResponse
            {
                Id = appUser.Id,
                Name = appUser.Name,
                Surname = appUser.Surname,
                Username = appUser.Username,
                Password = appUser.Password,
                Email = appUser.Email,
                AppRoleId = appUser.AppRoleId,
                RoleName = role.AppRoleName,
                CreatedTime = appUser.CreatedTime,
                UpdatedTime = appUser.UpdatedTime
            };

        }
    }
}
