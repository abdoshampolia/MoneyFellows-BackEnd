using MoneyFellows.Core.Common.Contracts;

namespace MoneyFellows.Core.Common
{
    public abstract class ModifiableEntity : IModifiableEntityBase, IEntityBase
    {
        protected ModifiableEntity(Guid creatorUserId)
        {
            CreatorUserId = creatorUserId;
            CreatedOn = DateTime.UtcNow;
            ModifierUserId = null;
            ModifiedOn = null;
            IsDeleted = false;
            DeletingUserId = null;
            DeletedOn = null;
        }

        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid? ModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public Guid? DeletingUserId { get; set; }
    }
}