namespace Service.Pool
{
    public interface ICreator<T>
    {
        T Instantiate(T prototype);
    }
}
