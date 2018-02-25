using UnityEngine;

namespace Service.Pool
{
    [CreateAssetMenu(fileName = "StretchPool", menuName = "Pool/StretchPool")]
    public class StretchPoolSetup : BasePoolSetup
    {
        protected override BasePool<T> CreatePool<T>(ICreator<T> creator)
        {
            return new StretchDynamicPool<T>(creator, _prefab as T, _size);
        }
    }
}
