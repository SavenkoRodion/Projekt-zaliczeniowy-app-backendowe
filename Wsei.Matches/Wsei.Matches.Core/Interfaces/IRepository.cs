namespace Wsei.Matches.Core.Interfaces
{
    public interface IRepository<Request, Response>
    {
        public Task<IEnumerable<Response>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Response?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task DeleteAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        public Task AddAsync(IEnumerable<Request> objs, CancellationToken cancellationToken);
        public Task UpdateAsync(IEnumerable<Request> objToUpdate, CancellationToken cancellationToken);
    }
}
