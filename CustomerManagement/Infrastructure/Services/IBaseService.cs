namespace CustomerManagement.Infrastructure.Services
{
    public interface IBaseService<TEntity>
    {
        public Task<List<TEntity>> GetAll(int? parentId);
        public Task<TEntity> GetById(int resourceId);
        public Task<bool> Post(TEntity entity);
        public Task<bool> Delete(int id);
        public Task<TEntity> Put(int id, TEntity entity);
    }
}
