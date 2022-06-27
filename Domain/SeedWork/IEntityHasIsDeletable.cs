namespace Domain.SeedWork
{
    public interface IEntityHasIsDeletable : IEntityHasRemoverUser
    {
        bool IsDeletable { get; set; }
    }
}
