using UnityEngine;

namespace Service.Pool
{
    [CreateAssetMenu(fileName = "StaticPool", menuName = "Pool/StaticPool")]
    public class StaticPoolSetup : BasePoolSetup
    {
        protected override BasePool<T> CreatePool<T>(ICreator<T> creator)
        {
            return new StaticPool<T>(creator, _prefab as T, _size);
        }
    }
}
