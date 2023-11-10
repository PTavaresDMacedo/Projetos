namespace McKing.Service.Interface
{
    public interface IService<T, PK>
    {
        T Create(T type);
        T Retrieve(PK id);
        List<T> RetrieveAll();
        T Update(T type);
        void Delete(PK id);
    }
}
