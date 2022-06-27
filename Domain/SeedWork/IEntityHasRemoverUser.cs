namespace Domain.SeedWork
{
    public interface IEntityHasRemoverUser : IEntityHasDeleteDateTime
    {
        public System.Guid RemoverUserId { get; }
        void SetRemoverUserId(System.Guid userId);
    }
}
