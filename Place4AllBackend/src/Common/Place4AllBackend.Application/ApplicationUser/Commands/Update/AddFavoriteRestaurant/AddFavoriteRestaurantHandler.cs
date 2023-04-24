using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant
{
    public class AddFavoriteRestaurantHandler : IRequestHandlerWrapper<AddFavoriteRestaurantCommand, ApplicationUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public AddFavoriteRestaurantHandler (IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(AddFavoriteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Where(x => x.Id == request.FavoriteRestaurantId).FirstOrDefaultAsync(cancellationToken);
            var entity = await  _identityService.AddFavoriteRestaurant(restaurant, _currentUserService.UserId);
            return ServiceResult.Success(_mapper.Map<ApplicationUserDto>(entity));
        }
    }
}
