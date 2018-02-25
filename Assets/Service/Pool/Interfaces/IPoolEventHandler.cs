using UnityEngine;

namespace Service.Pool
{
    public interface IPoolEventHandler
    {
        void OnInstantiate(Component component);
        void OnGet(Component component);
        void OnReturn(Component component);
    }
}
