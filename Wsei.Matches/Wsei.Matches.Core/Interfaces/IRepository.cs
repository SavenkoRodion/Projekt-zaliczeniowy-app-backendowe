namespace Wsei.Matches.Core.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
    }
}
