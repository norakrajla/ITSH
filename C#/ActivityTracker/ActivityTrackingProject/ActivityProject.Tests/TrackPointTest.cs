using ActivityProject.Exercises;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivityProject.Tests
{

    [TestClass]
    public class TrackPointTest
    {
        TrackPoint trackPoint = new TrackPoint(new Coordinate(12.5, 34.89), 123);
        TrackPoint trackPoint2 = new TrackPoint(new Coordinate(12.6, 34.123), 200);

        [TestMethod]
        public void TestCreateTrackPoint()
        {
            Assert.AreEqual(34.89, trackPoint.Coordinate.Longitude);
            Assert.AreEqual(12.5, trackPoint.Coordinate.Latitude);
            Assert.AreEqual(123.0, trackPoint.Elevation);
        }

        [TestMethod]
        public void TestCalculateDistance()
        {
            Assert.AreEqual(83988.06115, trackPoint.CalculateDistanceFrom(trackPoint2));
        }
    }
}

