using UnityEngine;

namespace Service.Pool
{
    public class UnlimitedDynamicPool<T> : DynamicPool<T> where T : Object
    {
        public UnlimitedDynamicPool(ICreator<T> creator, T prototype, int size)
            : base(creator, prototype, size)
        { }

        public override T Get()
        {
            T result = default(T);
            if (_stack.Count > 0)
            {
                result = _stack.Pop();
            }
            else
            {
                result = _creator.Instantiate(_prototype);
            }
            return result;
        }
    }
}
