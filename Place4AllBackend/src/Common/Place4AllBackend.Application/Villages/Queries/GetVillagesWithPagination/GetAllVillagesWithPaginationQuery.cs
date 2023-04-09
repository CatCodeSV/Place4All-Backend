using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Mapping;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Mapster;
using MapsterMapper;

namespace Place4AllBackend.Application.Villages.Queries.GetVillagesWithPagination
{
    public class GetAllVillagesWithPaginationQuery : IRequestWrapper<PaginatedList<VillageDto>>
    {
        public int DistrictId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class
        GetAllVillagesWithPaginationQueryHandler : IRequestHandlerWrapper<GetAllVillagesWithPaginationQuery,
            PaginatedList<VillageDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllVillagesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PaginatedList<VillageDto>>> Handle(GetAllVillagesWithPaginationQuery request,
            CancellationToken cancellationToken)
        {
            PaginatedList<VillageDto> list = await _context.Villages
                .Where(x => x.DistrictId == request.DistrictId)
                .OrderBy(o => o.Name)
                .ProjectToType<VillageDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            return list.Items.Any()
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<PaginatedList<VillageDto>>(ServiceError.NotFound);
        }
    }
}