using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Services.Restaurants.Commands.Delete
{
    public class DeleteRestaurantHandler : IRequestHandlerWrapper<DeleteRestaurantCommand, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteRestaurantHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RestaurantDto>> Handle(DeleteRestaurantCommand request,
            CancellationToken cancellationToken)
        {
            var restaurantToDelete = await _context.Restaurants.Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (restaurantToDelete == null)
            {
                return ServiceResult.Failed<RestaurantDto>(ServiceError.NotFound);
            }

            _context.Restaurants.Remove(restaurantToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<RestaurantDto>(restaurantToDelete));
        }
    }
}