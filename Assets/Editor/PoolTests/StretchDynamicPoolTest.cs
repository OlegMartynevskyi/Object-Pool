using NUnit.Framework;
using UnityEngine;

namespace Service.Pool.Test
{
    class StretchDynamicPoolTest
    {        
        [Test]
        public void Constructor_SizeLessZero_ArgumentOutOfRangeException()
        {            
            Assert.Throws<System.ArgumentOutOfRangeException>(
                () => new StretchDynamicPool<BoxCollider>(new BoxColliderFakeCreator(), null, -1));
        }

        [Test]
        public void GetThenReturn_ConstantSize()
        {            
            var pool = new StretchDynamicPool<BoxCollider>(new BoxColliderFakeCreator(), null, 1);
            int poolSize = pool.Size;

            var obj = pool.Get();
            pool.Return(obj);

            Assert.That(poolSize, Is.EqualTo(pool.Size));
        }

        [Test]
        public void Get_FromEmpty_ReturnNewValue()
        {
            var pool = new StretchDynamicPool<BoxCollider>(new BoxColliderFakeCreator(), null, 0);

            var result = pool.Get();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Return_WhenFull_SameSize()
        {
            var pool = new StretchDynamicPool<BoxCollider>(new BoxColliderFakeCreator(), null, 0);
            int poolSize = pool.Size;

            var result = pool.Get();
            pool.Return(result);

            Assert.That(poolSize, Is.EqualTo(pool.Size));
        }

        private class BoxColliderFakeCreator : ICreator<BoxCollider>
        {
            public BoxCollider Instantiate(BoxCollider prototype)
            {
                var obj = new GameObject();
                return obj.AddComponent<BoxCollider>();
            }
        }
    }
}
