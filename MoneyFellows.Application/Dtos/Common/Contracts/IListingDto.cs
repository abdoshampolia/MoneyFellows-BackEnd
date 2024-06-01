
namespace MoneyFellows.Application.Dtos.Common.Contracts
{
    public interface IListingDto<TEntityDtoOutput>
    {
        public List<TEntityDtoOutput> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
    }
}
