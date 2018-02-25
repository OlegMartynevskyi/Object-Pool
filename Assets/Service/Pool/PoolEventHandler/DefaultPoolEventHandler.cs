using UnityEngine;

namespace Service.Pool
{
    public class DefaultPoolEventHandler : IPoolEventHandler
    {
        public void OnGet(Component component)
        {
            component.gameObject.SetActive(true);
        }

        public void OnInstantiate(Component component)
        {
            component.gameObject.SetActive(false);
        }

        public void OnReturn(Component component)
        {
            component.gameObject.SetActive(false);
        }
    }
}
