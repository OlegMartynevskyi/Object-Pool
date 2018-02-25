using UnityEngine;

namespace Service.Pool
{
    public abstract class BasePoolSetup : ScriptableObject, IPoolFactory
    {
        [SerializeField]
        protected MonoBehaviour _prefab;
        [SerializeField]
        protected int _size;

        public BasePool<T> MakePool<T>(ICreator<T> creator) where T : Component
        {
            if (_prefab is T)
            {
                return CreatePool(creator);
            }
            else
            {
                throw new System.Exception(string.Format("Setup {0} _prefab Type {1} is not {2}", name, _prefab.GetType().Name, typeof(T).Name));
            }
        }

        protected abstract BasePool<T> CreatePool<T>(ICreator<T> creator) where T : Component;
    }
}
