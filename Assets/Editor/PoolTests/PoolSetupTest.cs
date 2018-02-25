using NUnit.Framework;
using Service.Utils;
using System;
using UnityEngine;

namespace Service.Pool.Test
{
    class PoolSetupTest
    {
        [Test]
        public void MakePool_InvalidPrefabType_ThrowException()
        {
            var setup = ScriptableObject.CreateInstance<FakePoolSetup>();

            var ex = Assert.Throws<Exception>(() => setup.MakePool(new FakeCreator<TestBehaviour>()));

            Assert.IsTrue(ex.Message.Contains("prefab", StringComparison.OrdinalIgnoreCase));
        }
    }
}
