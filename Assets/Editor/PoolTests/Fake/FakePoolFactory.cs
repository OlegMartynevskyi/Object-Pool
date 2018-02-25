using UnityEngine;

namespace Service.Pool.Test
{
    public class FakePoolFactory : IPoolFactory
    {
        public BasePool<T> MakePool<T>(ICreator<T> creator) where T : Component
        {
            var obj = new GameObject();
            var prototype = obj.AddComponent<T>();
            return new StaticPool<T>(creator, prototype, 1);
        }
    }
}
