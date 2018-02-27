using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service.Pool
{
    public class PoolActiveObjects<T> : IActiveObjectsCollection<T>, IEnumerable<T> where T : Component
    {
        private readonly List<T> _activeObjects = new List<T>();                

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _activeObjects.Count - 1; i >= 0; --i)
            {
                yield return _activeObjects[i];
            }
        }                

        public void Init(T component)
        {
            component.gameObject.SetActive(false);
        }

        public void Add(T component)
        {
            component.gameObject.SetActive(true);
            _activeObjects.Add(component);
        }

        public bool Remove(T component)
        {            
            component.gameObject.SetActive(false);
            return _activeObjects.Remove(component);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
