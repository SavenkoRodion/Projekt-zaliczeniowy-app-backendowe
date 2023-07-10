﻿namespace Wsei.TeamRatingsApi.Core.Interfaces
{
    public interface IRepository<Request, Response>
    {
        public Task<IEnumerable<Response>> GetAllAsync();
        public Task<Response?> GetByIdAsync(int id);
        public Task DeleteAsync(IEnumerable<int> ids);
        public Task AddAsync(IEnumerable<Request> objs);
        public Task ReplaceAsync(IEnumerable<Request> objToUpdate);
    }
}
