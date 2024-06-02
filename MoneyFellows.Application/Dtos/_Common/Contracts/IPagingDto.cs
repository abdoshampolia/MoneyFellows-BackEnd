namespace MoneyFellows.Application.Dtos.Common.Contracts
{
    public interface IPagingDto
    {
        int? PageNumber { get; set; }

        int? PageSize { get; set; }
    }
}
