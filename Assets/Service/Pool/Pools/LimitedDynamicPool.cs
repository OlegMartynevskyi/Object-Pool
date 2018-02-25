using UnityEngine;

namespace Service.Pool
{
    public class LimitedDynamicPool<T> : DynamicPool<T> where T : Object
    {
        private int _maxSize;
        private int _size;

        public bool LimitReached { get { return _size >= _maxSize; } }

        public LimitedDynamicPool(ICreator<T> creator, T prototype, int size, int maxSize)
            : base(creator, prototype, size)
        {            
            _maxSize = maxSize < size ? size : maxSize;
        }

        public LimitedDynamicPool(ICreator<T> creator, T prototype, int size)
            : base(creator, prototype, size)
        {
            _maxSize = size;
        }

        public override T Get()
        {
            T result = default(T);
            if (!LimitReached)
            {             
                if (_stack.Count > 0)
                {
                    result = _stack.Pop();
                }
                else
                {
                    result = _creator.Instantiate(_prototype);
                }
                ++_size;
            }
            return result;
        }        

        public override void Return(T instance)
        {
            base.Return(instance);
            --_size;
        }
    }
}
