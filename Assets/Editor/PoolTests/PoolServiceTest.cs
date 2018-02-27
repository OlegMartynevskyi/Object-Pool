using NUnit.Framework;

namespace Service.Pool.Test
{
    class PoolServiceTest
    {
        [Test]
        public void Constructor_TriggeredPoolEventHandler_OnInstantiate()
        {
            var poolEventHandler = new FakePoolEventHandler<TestBehaviour>();

            new PoolService<TestBehaviour>(poolEventHandler, new FakePoolFactory());            

            Assert.That(poolEventHandler.InitTriggered, Is.True);
        }

        [Test]
        public void Get_TriggeredPoolEventHandler_OnGet()
        {
            var poolEventHandler = new FakePoolEventHandler<TestBehaviour>();
            var poolService = new PoolService<TestBehaviour>(poolEventHandler, new FakePoolFactory());

            poolService.Get();

            Assert.That(poolEventHandler.AddTriggered, Is.True);
        }

        [Test]
        public void Return_TriggeredPoolEventHandler_OnReturn()
        {
            var poolEventHandler = new FakePoolEventHandler<TestBehaviour>();
            var poolService = new PoolService<TestBehaviour>(poolEventHandler, new FakePoolFactory());

            var obj = poolService.Get();
            poolService.Return(obj);

            Assert.That(poolEventHandler.RemoveTriggered, Is.True);
        }
    }
}
