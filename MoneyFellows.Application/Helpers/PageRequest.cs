using MoneyFellows.Application.Dtos.Common.Contracts;

namespace MoneyFellows.Application.Helpers
{
    public class PageRequest : IPagingDto
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string? OrderBy { get; set; } = null;
        public bool IsAcending { get; set; } = true;
    }
}
