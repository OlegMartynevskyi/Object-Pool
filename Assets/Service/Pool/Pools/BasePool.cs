using System.Collections.Generic;

namespace Service.Pool
{    
    public abstract class BasePool<T>
    {        
        protected Stack<T> _stack = null;

        public int Size { get { return _stack.Count; } }

        public BasePool(int size)
        {
            _stack = new Stack<T>(size);
        }

        public abstract T Get();
        public abstract void Return(T instance);
    }
}