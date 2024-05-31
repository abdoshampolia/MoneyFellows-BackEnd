namespace MoneyFellows.Core.Common.Contracts
{
    public interface IModifiableEntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid? ModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public Guid? DeletingUserId { get; set; }
    }
}
