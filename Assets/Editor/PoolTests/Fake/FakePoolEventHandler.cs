using UnityEngine;
using Service.Pool;

namespace Service.Pool.Test
{
    class FakePoolEventHandler<T> : IActiveObjectsCollection<T> where T : Component
    {
        public bool AddTriggered { get; private set; }
        public bool InitTriggered { get; private set; }
        public bool RemoveTriggered { get; private set; }

        public void Add(T component)
        {
            AddTriggered = true;
        }

        public void Init(T component)
        {
            InitTriggered = true;
        }

        public bool Remove(T component)
        {
            return RemoveTriggered = true;
        }
    }
}
