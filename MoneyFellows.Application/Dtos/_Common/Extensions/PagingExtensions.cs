
namespace MoneyFellows.Application.Dtos.Common.Extensions
{
    public static class PagingExtensions
    {
        public static IQueryable<TSource> PagingBy<TSource>(this IQueryable<TSource> source, int? pageNumber = null, int? itemsPerPage = null)
        {
            IQueryable<TSource> result;
            if (pageNumber > 0 && itemsPerPage > 0)
            {
                result = source
                    .Skip((pageNumber.Value - 1) * itemsPerPage.Value)
                    .Take(itemsPerPage.Value);
            }
            else
            {
                result = source;
            }
            return result;
        }
    }
}
