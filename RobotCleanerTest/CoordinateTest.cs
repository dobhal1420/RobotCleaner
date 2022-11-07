using RobotCleanerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerTest
{
    public class CoordinateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenCoordinateCreateCoordinates()
        {

            Coordinate position = new Coordinate(1,10);

            Assert.That(position.X, Is.EqualTo(1));
            Assert.That(position.Y, Is.EqualTo(10));
        }

        [Test]
        public void GivenOutOfBoundCoordinateCreateValidCoordinates()
        {

            Coordinate position = new Coordinate(-20000, 20000);

            Assert.That(position.X, Is.EqualTo(-10000));
            Assert.That(position.Y, Is.EqualTo(10000));
        }

        [Test]
        public void GivenTwoCoordinatesCompareThemResult()
        {

            Coordinate position1 = new Coordinate(5, 90);
            Coordinate position2 = new Coordinate(5, 90);

            Assert.True(position1.Equals(position2));

        }

    }
}
