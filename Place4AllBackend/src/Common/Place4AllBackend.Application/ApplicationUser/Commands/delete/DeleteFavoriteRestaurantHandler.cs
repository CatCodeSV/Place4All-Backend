using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Delete
{
    internal class DeleteFavoriteRestaurantHandler : IRequestHandlerWrapper<DeleteFavoriteRestaurantCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public DeleteFavoriteRestaurantHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(DeleteFavoriteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Where(x => x.Id == request.FavoriteRestaurantId).FirstOrDefaultAsync(cancellationToken);
            var entity = await _identityService.DeleteFavoriteRestaurant(restaurant, _currentUserService.UserId);

            if (entity == null)
            {
                throw new NotFoundException();
            }
            return ServiceResult.Success(_mapper.Map<ApplicationUserDto>(entity));
        }
    }
}
