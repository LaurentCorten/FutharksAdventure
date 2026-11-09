using FutharksAdventure.Core;
using NUnit.Framework;

namespace FutharksAdventure.Tests
{
    public class EventBusTests
    {
        private struct TestEvent { public int Value; }
        private struct OtherEvent { }

        private EventBus _bus;

        [SetUp]
        public void SetUp() => _bus = new EventBus();

        [Test]
        public void Publish_CallsSubscriberWithEvent()
        {
            int received = 0;
            _bus.Subscribe<TestEvent>(e => received = e.Value);

            _bus.Publish(new TestEvent { Value = 42 });

            Assert.That(received, Is.EqualTo(42));
        }

        [Test]
        public void Publish_CallsAllSubscribers()
        {
            int calls = 0;
            _bus.Subscribe<TestEvent>(_ => calls++);
            _bus.Subscribe<TestEvent>(_ => calls++);

            _bus.Publish(new TestEvent());

            Assert.That(calls, Is.EqualTo(2));
        }

        [Test]
        public void Publish_WithoutSubscriber_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _bus.Publish(new TestEvent()));
        }

        [Test]
        public void Publish_DoesNotCallSubscribersOfOtherType()
        {
            bool called = false;
            _bus.Subscribe<OtherEvent>(_ => called = true);

            _bus.Publish(new TestEvent());

            Assert.That(called, Is.False);
        }

        [Test]
        public void Unsubscribe_StopsReceivingEvents()
        {
            int calls = 0;
            void Handler(TestEvent e) => calls++;
            _bus.Subscribe<TestEvent>(Handler);
            _bus.Unsubscribe<TestEvent>(Handler);

            _bus.Publish(new TestEvent());

            Assert.That(calls, Is.EqualTo(0));
        }
    }
}