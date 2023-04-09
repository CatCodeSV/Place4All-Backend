﻿using Mapster;
using MapsterMapper;
using MediatR;
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

namespace Place4AllBackend.Application.Restaurants.Queries
{
    public class GetRestaurantById : IRequestWrapper<RestaurantDto>
    {
        public int RestaurantId { get; set; }
    }

    public class GetRestaurantByIdQueryHandler : IRequestHandlerWrapper<GetRestaurantById, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantByIdQueryHandler (IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<ServiceResult<RestaurantDto>> IRequestHandler<GetRestaurantById, ServiceResult<RestaurantDto>>.Handle(GetRestaurantById request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Where(x => x.Id == request.RestaurantId).Include(a => a.Address).Include(f => f.Features).Include(i => i.Images).ProjectToType<RestaurantDto>(_mapper.Config).FirstOrDefaultAsync(cancellationToken);

            return restaurant != null ? ServiceResult.Success(restaurant) : ServiceResult.Failed<RestaurantDto>(ServiceError.NotFound);
        }
    }

}
