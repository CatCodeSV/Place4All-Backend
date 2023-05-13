using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Models;


using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Application.Common.Interfaces;

namespace Place4AllBackend.Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable,
            IMapper mapper, CancellationToken cancellationToken)
            => queryable.ProjectTo<TDestination>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}