using Application.Features.Mediatr.TagCommands.UpdateTag;
using Application.Repositories.AppRoleRepository;
using Application.Repositories.AppUserRepository;
using Application.Repositories.TagRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserCommands.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, UpdateAppUserCommandResponse>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IReadAppUserRepository _readAppUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;

        public UpdateAppUserCommandHandler(IAppUserRepository appUserRepository, IReadAppUserRepository readAppUserRepository, IAppRoleRepository appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _readAppUserRepository = readAppUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<UpdateAppUserCommandResponse> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = _readAppUserRepository.GetByIdAsync(request.Id).Result;
           // var appRole = _appRoleRepository.GetByIdAsync(request.AppRoleId).Result;

            appUser.Username = request.Username;
            appUser.Password = request.Password;
            appUser.Name = request.Name;
            appUser.Surname = request.Surname;
            appUser.Email = request.Email;
            appUser.UpdatedTime = DateTime.UtcNow;
            //appUser.AppRoleId = request.AppRoleId;
            //appUser.AppRole.AppRoleName = request.AppRoleName;

            await _appUserRepository.SaveAsync();
            return new UpdateAppUserCommandResponse()
            {
                Message = "AppUser Updated Successfully"
            };
        }
    }

}
