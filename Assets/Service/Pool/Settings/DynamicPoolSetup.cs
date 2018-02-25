using UnityEngine;

namespace Service.Pool
{
    [CreateAssetMenu(fileName = "DynamicPool", menuName = "Pool/DynamicPool")]
    public class DynamicPoolSetup : BasePoolSetup
    {
        [Tooltip(tooltip:"Size Unlimited if <= 0")]
        [SerializeField]
        private int _maxSize = 0;

        public bool Unlimited { get { return _maxSize <= 0; } }

        protected override BasePool<T> CreatePool<T>(ICreator<T> creator)
        {
            if (Unlimited)
            {
                return new UnlimitedDynamicPool<T>(creator, _prefab as T, _size);
            }
            else
            {
                return new LimitedDynamicPool<T>(creator, _prefab as T, _size, _maxSize);
            }
        }
    }
}
