using NUnit.Framework;
using UnityEngine;

namespace Service.Pool.Test
{
    class LimitedDynamicPoolTest : StaticPoolTest
    {
        protected override BasePool<GameObject> GetPool(ICreator<GameObject> creator, GameObject prototype, int size)
        {
            return new LimitedDynamicPool<GameObject>(creator, prototype, size, 1);
        }

        [Test]
        public void Get_WhenLimitReached_ReturnDefaultValue()
        {
            var pool = new LimitedDynamicPool<GameObject>(new FakeCreator<GameObject>(), new GameObject(), 1);
                        
            while (!pool.LimitReached)
            {
                pool.Get();
            }

            var result = pool.Get();

            Assert.That(result, Is.Null);
        }
    }
}
