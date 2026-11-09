//using System.Collections.Generic;
//using FutharksAdventure.Core;
//using NUnit.Framework;

//namespace FutharksAdventure.Tests
//{
//    public class TurnManagerTests
//    {
//        private EventBus _bus;
//        private OccupancyMap _occupancy;
//        private Player _player;
//        private TurnManager _turnManager;

//        [SetUp]
//        public void SetUp()
//        {
//            var grid = TestFloors.CreateRoom3x3();
//            _bus = new EventBus();
//            _occupancy = new OccupancyMap();
//            _player = new Player();
//            _occupancy.Place(_player, new GridPosition(2, 3)); // contre le mur Nord

//            var resolver = new IntentResolver(grid, _occupancy, _bus);
//            _turnManager = new TurnManager(_player, resolver, _bus);
//        }

//        [Test]
//        public void SubmitMove_Valid_ReturnsTrueAndMovesPlayer()
//        {
//            bool accepted = _turnManager.SubmitMove(Direction.South);

//            Assert.That(accepted, Is.True);
//            Assert.That(_player.Position, Is.EqualTo(new GridPosition(2, 2)));
//        }

//        [Test]
//        public void SubmitMove_Valid_PublishesTurnResolved()
//        {
//            bool resolved = false;
//            _bus.Subscribe<TurnResolved>(_ => resolved = true);

//            _turnManager.SubmitMove(Direction.South);

//            Assert.That(resolved, Is.True);
//        }

//        [Test]
//        public void SubmitMove_IntoWall_ReturnsFalseAndPublishesNoTurn()
//        {
//            bool resolved = false;
//            _bus.Subscribe<TurnResolved>(_ => resolved = true);

//            bool accepted = _turnManager.SubmitMove(Direction.North);

//            Assert.That(accepted, Is.False);
//            Assert.That(resolved, Is.False);
//            Assert.That(_player.Position, Is.EqualTo(new GridPosition(2, 3)));
//        }

//        [Test]
//        public void SubmitMove_Valid_PublishesEntityMovedBeforeTurnResolved()
//        {
//            var log = new List<string>();
//            _bus.Subscribe<EntityMoved>(_ => log.Add("moved"));
//            _bus.Subscribe<TurnResolved>(_ => log.Add("turn"));

//            _turnManager.SubmitMove(Direction.South);

//            Assert.That(log, Is.EqualTo(new[] { "moved", "turn" }));
//        }
//    }
//}