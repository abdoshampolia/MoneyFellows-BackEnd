using MoneyFellows.Application.Dtos.Common.Contracts;

namespace MoneyFellows.Application.Helper
{
    public class PageRequest : IPagingDto
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

    }
}
