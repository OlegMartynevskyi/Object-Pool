using UnityEngine;

namespace Service.Pool
{    
    public class PoolService<T> : ICreator<T> where T : Component
    {        
        private BasePool<T> _pool;

        private IActiveObjectsCollection<T> _activeObjects;

        public PoolService(IActiveObjectsCollection<T> activeObjects, IPoolFactory poolFactory) 
        {            
            _activeObjects = activeObjects;
            _pool = poolFactory.MakePool(this);
        }

        T ICreator<T>.Instantiate(T prototype)
        {
            T instance = null;
            if (prototype != null)
            {
                GameObject obj = Object.Instantiate(prototype.gameObject);
                instance = obj.GetComponent<T>();
                _activeObjects.Init(instance);
            }
            return instance;
        }

        public T Get() 
        {
            T result = _pool.Get();
            if (result != null)
            {                         
                _activeObjects.Add(result);
            }
            return result;
        }

        public void Return(T component)
        {
            if (component != null)
            {
                if (_activeObjects.Remove(component))
                {   
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
    }
}
