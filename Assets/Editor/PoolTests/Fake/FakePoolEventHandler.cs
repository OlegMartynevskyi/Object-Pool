using UnityEngine;

namespace Service.Pool.Test
{
    class FakePoolEventHandler : IPoolEventHandler
    {
        public bool GetTriggered { get; private set; }
        public bool InstantiateTriggered { get; private set; }
        public bool ReturnTriggered { get; private set; }

        public void OnGet(Component component)
        {
            GetTriggered = true;
        }

        public void OnInstantiate(Component component)
        {
            InstantiateTriggered = true;
        }

        public void OnReturn(Component component)
        {
            ReturnTriggered = true;
        }
    }
}
