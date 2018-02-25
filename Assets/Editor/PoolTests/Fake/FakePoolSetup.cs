using UnityEngine;

namespace Service.Pool.Test
{
    public class FakePoolSetup : BasePoolSetup
    {
        private void Awake()
        {
            _prefab = new GameObject().AddComponent<InvalidBehaviour>();
        }

        protected override BasePool<T> CreatePool<T>(ICreator<T> creator)
        {
            return null;
        }
    }
}
