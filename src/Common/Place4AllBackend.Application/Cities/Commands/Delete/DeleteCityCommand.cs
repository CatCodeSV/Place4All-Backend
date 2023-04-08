using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Place4AllBackend.Application.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequestWrapper<CityDto>
    {
        public int Id { get; set; }
    }

    public class DeleteCityCommandHandler : IRequestHandlerWrapper<DeleteCityCommand, CityDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cities
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }

            _context.Cities.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CityDto>(entity));
        }
    }
}