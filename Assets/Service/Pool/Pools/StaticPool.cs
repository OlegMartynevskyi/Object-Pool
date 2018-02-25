using UnityEngine;

namespace Service.Pool
{
    public class StaticPool<T> : BasePool<T> where T : Object
    {
        public StaticPool(ICreator<T> creator, T prototype, int size)
            : base(size)
        {
            for (int i = 0; i < size; ++i)
            {
                T obj = creator.Instantiate(prototype);                
                _stack.Push(obj);
            }
        }

        public override T Get()
        {
            T result = default(T);
            if (_stack.Count > 0)
            {
                result = _stack.Pop();
            }
            return result;
        }

        public override void Return(T instance)
        {
            _stack.Push(instance);
        }
    }
}
