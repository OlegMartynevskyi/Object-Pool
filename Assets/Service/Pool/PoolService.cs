using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Service.Pool
{    
    public class PoolService<T> : ICreator<T>, IEnumerable<T> where T : Component
    {
        private readonly List<T> activeObjects = new List<T>();
        private BasePool<T> _pool;

        private IPoolEventHandler eventHandler;

        public PoolService(IPoolEventHandler poolEventHandler, IPoolFactory poolFactory) 
        {            
            eventHandler = poolEventHandler;
            _pool = poolFactory.MakePool(this);
        }

        public T this[int index]
        {
            get
            {
                return activeObjects[index];
            }
        }

        T ICreator<T>.Instantiate(T prototype)
        {
            T instance = null;
            if (prototype != null)
            {
                GameObject obj = Object.Instantiate(prototype.gameObject);
                instance = obj.GetComponent<T>();
                eventHandler.OnInstantiate(instance);
            }
            return instance;
        }

        public T Get() 
        {
            T result = _pool.Get();
            if (result != null)
            {                
                activeObjects.Add(result);
                eventHandler.OnGet(result);
            }
            return result;
        }

        public void Return(T component)
        {
            if (component != null)
            {
                if (activeObjects.Remove(component))
                {
                    eventHandler.OnReturn(component);
                    _pool.Return(component);
                }                
#if UNITY_EDITOR
                else
                {
                    Debug.LogError(component.name + "isn't in pool");
                    Object.Destroy(component.gameObject);
                }
#endif
            }
        }        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = activeObjects.Count - 1; i >= 0; --i)
            {
                yield return activeObjects[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
