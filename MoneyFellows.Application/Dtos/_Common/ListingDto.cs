using MoneyFellows.Application.Dtos.Common.Contracts;
using MoneyFellows.Application.Dtos.Common.Extensions;

namespace MoneyFellows.Application.Dtos.Common
{
    public class ListingDto<TEntityDtoOutput> : IListingDto<TEntityDtoOutput>
    {
        public ListingDto(IQueryable<TEntityDtoOutput>? source, int? pageNumber = null, int? pageSize = null)
        {
            if (source != null)
            {
                var count = source.ToList().Count;
                IQueryable<TEntityDtoOutput> items = source.PagingBy(pageNumber, pageSize);

                PageNumber = pageNumber ?? 1;
                if (pageSize > 0)
                {
                    TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                }
                else if (count > 0)
                {
                    TotalPages = 1;
                }
                else
                {
                    TotalPages = 0;
                }

                TotalCount = count;
                Items = items.ToList();
            }
            else
            {
                Items = new List<TEntityDtoOutput>();
            }
        }

        public List<TEntityDtoOutput> Items { get; set; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}