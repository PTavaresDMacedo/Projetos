namespace McKing.Repository.Interface
{
    public interface IRepository<T, PK>
    {
        T Create(T type);
        T Retrieve(PK id);
        List<T> RetrieveAll();
        T Update(T type);
        void Delete(PK id);
    }
}
