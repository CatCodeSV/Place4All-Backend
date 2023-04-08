using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Restaurants.Commands.Create;

public record CreateRestaurantCommand(string Name, string Description) : IRequestWrapper<RestaurantDto>;

public class CreateRestaurantCommandHandler : IRequestHandlerWrapper<CreateRestaurantCommand, RestaurantDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateRestaurantCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ServiceResult<RestaurantDto>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var entity = new Restaurant()
        {
            Name = request.Name,
            Description = request.Description
        };

        await _context.Restaurants.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<RestaurantDto>(entity));
    }
}