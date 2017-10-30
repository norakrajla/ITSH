using ActivityProject.Exercises;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivityProject.Tests
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidLatitude()
        {
            Coordinate coordinate = new Coordinate(190.5, -34.789);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidLongitude()
        {
            Coordinate coordinate = new Coordinate(30.5, -200.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidCoordinate()
        {
            Coordinate coordinate = new Coordinate(-91.0, 180.1);
        }

        [TestMethod]
        public void TestCreateCoordinate()
        {
            Coordinate coordinate = new Coordinate(12.5, -34.789);
            Assert.AreEqual(12.5, coordinate.Latitude);
            Assert.AreEqual(-34.789, coordinate.Longitude);
        }
    }
}