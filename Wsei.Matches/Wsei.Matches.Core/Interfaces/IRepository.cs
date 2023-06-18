namespace Wsei.Matches.Core.Interfaces
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task AddAsync(IEnumerable<T> objs);
        public Task DeleteAsync(IEnumerable<int> ids);
        public Task UpdateAsync(IEnumerable<T> objToUpdate);
    }
}
