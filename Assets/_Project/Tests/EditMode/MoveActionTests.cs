//using FutharksAdventure.Core;
//using NUnit.Framework;

//namespace FutharksAdventure.Tests
//{
//    public class MoveActionTests
//    {
//        private FloorGrid _grid;
//        private OccupancyMap _occupancy;
//        private EventBus _bus;
//        private Player _player;

//        private static readonly GridPosition Center = new GridPosition(2, 2);
//        private static readonly GridPosition NorthOfCenter = new GridPosition(2, 3);

//        [SetUp]
//        public void SetUp()
//        {
//            _grid = TestFloors.CreateRoom3x3();
//            _occupancy = new OccupancyMap();
//            _bus = new EventBus();
//            _player = new Player();
//            _occupancy.Place(_player, Center);
//        }

//        private MoveAction CreateMove(Direction direction) =>
//            new MoveAction(_player, direction, _grid, _occupancy, _bus);

//        [Test]
//        public void CanExecute_TowardFloor_ReturnsTrue()
//        {
//            Assert.That(CreateMove(Direction.North).CanExecute(), Is.True);
//        }

//        [Test]
//        public void CanExecute_TowardWall_ReturnsFalse()
//        {
//            _occupancy.Move(_player, NorthOfCenter); // (2,4) est un mur

//            Assert.That(CreateMove(Direction.North).CanExecute(), Is.False);
//        }

//        [Test]
//        public void CanExecute_TowardOccupiedCell_ReturnsFalse()
//        {
//            _occupancy.Place(new Player(), NorthOfCenter);

//            Assert.That(CreateMove(Direction.North).CanExecute(), Is.False);
//        }

//        [Test]
//        public void CanExecute_DoesNotMoveEntity()
//        {
//            CreateMove(Direction.North).CanExecute();

//            Assert.That(_player.Position, Is.EqualTo(Center));
//        }

//        [Test]
//        public void TryExecute_TowardFloor_ReturnsTrueAndMovesEntity()
//        {
//            bool accepted = CreateMove(Direction.North).TryExecute();

//            Assert.That(accepted, Is.True);
//            Assert.That(_player.Position, Is.EqualTo(NorthOfCenter));
//        }

//        [Test]
//        public void TryExecute_TowardWall_ReturnsFalseAndDoesNotMove()
//        {
//            _occupancy.Move(_player, NorthOfCenter);

//            bool accepted = CreateMove(Direction.North).TryExecute();

//            Assert.That(accepted, Is.False);
//            Assert.That(_player.Position, Is.EqualTo(NorthOfCenter));
//        }

//        [Test]
//        public void TryExecute_Success_PublishesEntityMoved()
//        {
//            EntityMoved? received = null;
//            _bus.Subscribe<EntityMoved>(e => received = e);

//            CreateMove(Direction.North).TryExecute();

//            Assert.That(received.HasValue, Is.True);
//            Assert.That(received.Value.Entity, Is.SameAs(_player));
//            Assert.That(received.Value.From, Is.EqualTo(Center));
//            Assert.That(received.Value.To, Is.EqualTo(NorthOfCenter));
//        }

//        [Test]
//        public void TryExecute_Refused_PublishesNothing()
//        {
//            _occupancy.Move(_player, NorthOfCenter);
//            bool published = false;
//            _bus.Subscribe<EntityMoved>(_ => published = true);

//            CreateMove(Direction.North).TryExecute();

//            Assert.That(published, Is.False);
//        }
//    }
//}