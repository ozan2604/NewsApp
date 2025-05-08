using Application.Repositories.AppUserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.AppUserCommands.RemoveAppUser
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommandRequest, RemoveAppUserCommandResponse>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IReadAppUserRepository _readAppUserRepository;

        public RemoveAppUserCommandHandler(IAppUserRepository appUserRepository, IReadAppUserRepository readAppUserRepository)
        {
            _appUserRepository = appUserRepository;
            _readAppUserRepository = readAppUserRepository;
        }

        public async Task<RemoveAppUserCommandResponse> Handle(RemoveAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = _readAppUserRepository.GetByIdAsync(request.Id).Result;
            
            _appUserRepository.Remove(appUser);
            await _appUserRepository.SaveAsync();

            return new RemoveAppUserCommandResponse()
            {
                Message = "User Deleted Successfully"
            };
        }
    }
    
}
