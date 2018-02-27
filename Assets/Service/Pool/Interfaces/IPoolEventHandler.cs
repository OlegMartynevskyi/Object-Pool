namespace Service.Pool
{
    public interface IActiveObjectsCollection<T>
    {
        void Init(T component);
        void Add(T component);
        bool Remove(T component);
    }
}
