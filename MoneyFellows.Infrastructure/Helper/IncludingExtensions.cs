using Microsoft.EntityFrameworkCore;

namespace MoneyFellows.Application.Dtos.Common.Extensions
{
    public static class IncludingExtensions
    {
        public static IQueryable<TSource> IncludeProperties<TSource>(this IQueryable<TSource> source, string? includeProperties) where TSource : class
        {
            if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (',', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrEmpty(includeProperty))
                    {
                        source = source.Include(includeProperty);
                    }
                }
            }
            return source;
        }
    }
}
