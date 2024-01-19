namespace CustomerManagement.Infrastructure.Repositories
{
    public interface IBaseRepository<T>
    {
        T Read { get; }

        void Write(T data);
    }
}
