using NUnit.Framework;
using UnityEngine;

namespace Service.Pool.Test
{
    abstract class BasePoolTest
    {
        [Test]
        public void Constructor_SizeLessZero_ArgumentOutOfRangeException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(
                () => GetPool(new FakeCreator<GameObject>(), new GameObject(), -1));
        }

        [Test]
        public void GetThenReturn_ConstantSize()
        {
            var pool = GetPool(new FakeCreator<GameObject>(), new GameObject(), 1);
            int poolSize = pool.Size;

            var obj = pool.Get();
            pool.Return(obj);

            Assert.That(poolSize, Is.EqualTo(pool.Size));
        }

        protected abstract BasePool<GameObject> GetPool(ICreator<GameObject> creator, GameObject prototype, int size);
    }
}
