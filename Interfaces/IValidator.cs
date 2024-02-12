namespace DataAccess.Interfaces
{
    public interface IValidator<T>
    {
        Task ValidateOnAddAsync(T model);
        void ValidateOnDelete(int id);
    }
}
