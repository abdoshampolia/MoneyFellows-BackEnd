using AutoMapper;

namespace MoneyFellows.Application.Dtos.Common.Extensions
{
    public static class MappingExtensions
    {
        public static Task<ListingDto<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int? pageNumber = null, int? pageSize = null)
        {
            return Task.FromResult(new ListingDto<TDestination>(queryable, pageNumber, pageSize));
        }

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
        {
            return Task.FromResult(queryable.ProjectTo<TDestination>(configuration).ToList());
        }

        public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
        {
            return queryable.ProjectTo<TDestination>(configuration);
        }
    }
}
