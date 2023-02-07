namespace DP_SUM0023.Data.Services
{
    public interface ICRUDService<T, U>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(U id);
        public Task CreateAsync(T instanceToCreate);
        public Task UpdateAsync(T instanceToUpdate);
        public Task RemoveAsync(T instanceToRemove);
    }
}
