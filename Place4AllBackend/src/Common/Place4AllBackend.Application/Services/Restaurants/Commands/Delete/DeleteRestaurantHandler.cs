using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.Restaurants.Commands.Delete
{
    public class DeleteRestaurantHandler : IRequestHandlerWrapper<DeleteRestaurantCommand, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public async Task<ServiceResult<RestaurantDto>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantToDelete = await _context.Restaurants.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
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
