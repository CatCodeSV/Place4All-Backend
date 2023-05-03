using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Restaurants.Queries.GetRestaurants
{

    public class GetAllRestaurantsQuery : IRequestWrapper<List<RestaurantSummarizedDto>>
    {
    }

    public class GetRestaurantsHandler : IRequestHandlerWrapper<GetAllRestaurantsQuery, List<RestaurantSummarizedDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResult<List<RestaurantSummarizedDto>>> Handle(GetAllRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _context.Restaurants.Select(r => new RestaurantSummarizedDto()
            {
                Id = r.Id,
                Description = r.Description,
                Image = r.Images.FirstOrDefault().Link,
                Name = r.Name,
                PhoneNumber = r.PhoneNumber
            }).ProjectToType<RestaurantSummarizedDto>(_mapper.Config).ToListAsync(cancellationToken);

            return list.Count > 0
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<List<RestaurantSummarizedDto>>(ServiceError.NotFound);
        }
    }
}