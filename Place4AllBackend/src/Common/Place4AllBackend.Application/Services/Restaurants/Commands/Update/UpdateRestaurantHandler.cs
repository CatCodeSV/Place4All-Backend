using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.Restaurants.Commands.Update
{
    internal class UpdateRestaurantHandler : IRequestHandlerWrapper<UpdateRestaurantCommand, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRestaurantHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RestaurantDto>> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _context.Restaurants.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entityToUpdate == null)
            {
                return ServiceResult.Failed<RestaurantDto>(ServiceError.NotFound);
            }
            entityToUpdate.Name = request.Name;
            entityToUpdate.Description = request.Description;
            entityToUpdate.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success<RestaurantDto>(_mapper.Map<RestaurantDto>(entityToUpdate));
        }
    }
}
