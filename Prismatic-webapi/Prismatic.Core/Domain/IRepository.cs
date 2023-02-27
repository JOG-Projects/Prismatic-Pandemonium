namespace Prismatic.Core.Domain
{
    public interface IRepository<T>
    {
        public Task<Guid> Add(T entity);

        public Task<T> Get(Guid id);

        public Task<List<T>> GetAll();
    }
}
