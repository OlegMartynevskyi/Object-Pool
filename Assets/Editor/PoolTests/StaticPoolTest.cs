using NUnit.Framework;
using UnityEngine;

namespace Service.Pool.Test
{
    class StaticPoolTest : BasePoolTest
    {
        protected override BasePool<GameObject> GetPool(ICreator<GameObject> creator, GameObject prototype, int size)
        {
            return new StaticPool<GameObject>(creator, prototype, size);
        }        

        [Test]
        public void Get_FromEmpty_ReturnDefaultValue()
        {
            var pool = new StaticPool<GameObject>(new FakeCreator<GameObject>(), new GameObject(), 0);

            var result = pool.Get();

            Assert.That(result, Is.Null);
        }
    }
}
