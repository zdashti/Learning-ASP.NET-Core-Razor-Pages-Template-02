namespace Domain.SeedWork
{
    public interface IEntityHasUpdaterUser : IEntityHasUpdateDateTime
    {
        public System.Guid UpdaterUserId { get; }
        void SetUpdaterUserId(System.Guid userId);
    }
}
