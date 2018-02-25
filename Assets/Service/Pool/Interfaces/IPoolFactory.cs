using UnityEngine;

namespace Service.Pool
{
    public interface IPoolFactory
    {
        BasePool<T> MakePool<T>(ICreator<T> creator) where T : Component; 
    }
}
