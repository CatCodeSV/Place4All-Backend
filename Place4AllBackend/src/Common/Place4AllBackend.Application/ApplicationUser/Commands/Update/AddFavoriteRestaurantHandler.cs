using MapsterMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update
{
    public class AddFavoriteRestaurantHandler : IRequestHandlerWrapper<AddFavoriteRestaurantCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public AddFavoriteRestaurantHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(AddFavoriteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.FindAsync(request.FavoriteRestaurantId);
            var entity = await  _identityService.AddFavoriteRestaurant(restaurant, _currentUserService.UserId);
            return ServiceResult.Success(_mapper.Map<ApplicationUserDto>(entity));
        }
    }
}
