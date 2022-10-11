namespace MyApp.Application.Ports.Output
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
