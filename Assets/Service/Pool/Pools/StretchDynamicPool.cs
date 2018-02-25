using UnityEngine;

namespace Service.Pool
{
    public class StretchDynamicPool<T> : DynamicPool<T> where T : Component
    {
        private int _defaultSize;

        public StretchDynamicPool(ICreator<T> creator, T prototype, int size)
            : base(creator, prototype, size)
        {
            _defaultSize = size;
        }

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

        public override void Return(T instance)
        {
            if (_stack.Count == _defaultSize)
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    Object.Destroy(instance.gameObject);
                }
                else
                {
                    Object.DestroyImmediate(instance.gameObject);
                }
#else
                Object.Destroy(instance.gameObject);
#endif
            }
            else
            {
                base.Return(instance);                
            }            
        }
    }
}
