namespace Service.Pool.Test
{
    public class FakeCreator<T> : ICreator<T> where T : new()
    {
        public T Instantiate(T prototype)
        {
            return new T();
        }
    }
}
