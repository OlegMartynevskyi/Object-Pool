namespace Service.Pool
{
    public abstract class DynamicPool<T> : BasePool<T>
    {
        protected T _prototype;
        protected ICreator<T> _creator;

        public DynamicPool(ICreator<T> creator, T prototype, int size)
            : base(size)
        {
            for (int i = 0; i < size; ++i)
            {
                T instance = creator.Instantiate(prototype);
                _stack.Push(instance);
            }
            _prototype = prototype;
            _creator = creator;
        }

        public override void Return(T instance)
        {
            _stack.Push(instance);
        }
    }
}
