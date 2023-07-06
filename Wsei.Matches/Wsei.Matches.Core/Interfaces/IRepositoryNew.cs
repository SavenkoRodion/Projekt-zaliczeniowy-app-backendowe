namespace Wsei.Matches.Core.Interfaces
{
    public interface IRepositoryNew<Request, Response>
    {
        public Task<IEnumerable<Response>> GetAllAsync();
        public Task<Response?> GetByIdAsync(int id);
        public Task DeleteAsync(IEnumerable<int> ids);
        public Task AddAsync(IEnumerable<Request> objs);
        public Task UpdateAsync(IEnumerable<Request> objToUpdate);
    }
}
