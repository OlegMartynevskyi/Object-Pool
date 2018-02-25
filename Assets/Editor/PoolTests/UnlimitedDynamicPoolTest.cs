using NUnit.Framework;
using UnityEngine;

namespace Service.Pool.Test
{
    class UnlimitedDynamicPoolTest : BasePoolTest
    {
        protected override BasePool<GameObject> GetPool(ICreator<GameObject> creator, GameObject prototype, int size)
        {
            return new UnlimitedDynamicPool<GameObject>(creator, prototype, size);
        }

        [Test]
        public void Get_FromEmpty_ReturnNewValue()
        {
            var pool = GetPool(new FakeCreator<GameObject>(), new GameObject(), 0);

            var result = pool.Get();

            Assert.That(result, Is.Not.Null);
        }
    }
}    
