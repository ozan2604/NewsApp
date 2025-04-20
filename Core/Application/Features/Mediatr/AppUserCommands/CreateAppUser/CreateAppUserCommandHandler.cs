using Application.Enums;
using Application.Repositories;
using Application.Repositories.AppUserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserCommands.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        private readonly IAppUserRepository _appUserWriteRepository;

        public CreateAppUserCommandHandler(IAppUserRepository appUserWriteRepository)
        {
            _appUserWriteRepository = appUserWriteRepository;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _appUserWriteRepository.AddAsync(new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                AppRoleId = RolesType.Member // default member olarak eklendi
            });

            await _appUserWriteRepository.SaveAsync();
            return new CreateAppUserCommandResponse
            {
                Message = "User created successfully"
            };
        }
    }
}
