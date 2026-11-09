//using System;
//using FutharksAdventure.Core;
//using NUnit.Framework;

//namespace FutharksAdventure.Tests
//{
//    public class OccupancyMapTests
//    {
//        private OccupancyMap _map;
//        private Player _player;

//        [SetUp]
//        public void SetUp()
//        {
//            _map = new OccupancyMap();
//            _player = new Player();
//        }

//        [Test]
//        public void IsOccupied_EmptyCell_ReturnsFalse()
//        {
//            Assert.That(_map.IsOccupied(new GridPosition(1, 1)), Is.False);
//        }

//        [Test]
//        public void Place_SetsEntityPositionAndOccupiesCell()
//        {
//            var pos = new GridPosition(1, 1);

//            _map.Place(_player, pos);

//            Assert.That(_player.Position, Is.EqualTo(pos));
//            Assert.That(_map.IsOccupied(pos), Is.True);
//        }

//        [Test]
//        public void Place_OnOccupiedCell_Throws()
//        {
//            var pos = new GridPosition(1, 1);
//            _map.Place(_player, pos);

//            Assert.Throws<InvalidOperationException>(() => _map.Place(new Player(), pos));
//        }

//        [Test]
//        public void Place_SameEntityTwice_Throws()
//        {
//            _map.Place(_player, new GridPosition(1, 1));

//            Assert.Throws<InvalidOperationException>(
//                () => _map.Place(_player, new GridPosition(2, 2)));
//        }

//        [Test]
//        public void Move_UpdatesPositionAndCells()
//        {
//            var from = new GridPosition(1, 1);
//            var to = new GridPosition(1, 2);
//            _map.Place(_player, from);

//            _map.Move(_player, to);

//            Assert.That(_player.Position, Is.EqualTo(to));
//            Assert.That(_map.IsOccupied(from), Is.False);
//            Assert.That(_map.IsOccupied(to), Is.True);
//        }

//        [Test]
//        public void Move_ToOccupiedCell_Throws()
//        {
//            var other = new Player();
//            _map.Place(_player, new GridPosition(1, 1));
//            _map.Place(other, new GridPosition(1, 2));

//            Assert.Throws<InvalidOperationException>(
//                () => _map.Move(_player, new GridPosition(1, 2)));
//        }

//        [Test]
//        public void Move_EntityNotPlaced_Throws()
//        {
//            Assert.Throws<InvalidOperationException>(
//                () => _map.Move(_player, new GridPosition(1, 1)));
//        }
//    }
//}