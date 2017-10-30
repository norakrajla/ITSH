using ActivityProject.Exercises;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivityProject.Tests
{

    [TestClass]
    public class TrackTest
    {
        Track track = new Track();

        [TestMethod]
        public void AddItemGetPoinstsTest()
        {
            Assert.AreEqual(0, track.TrackPoints.Count);
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            Assert.AreEqual(1, track.TrackPoints.Count);
            Assert.AreEqual(34.89, track.TrackPoints[0].Coordinate.Longitude);
        }

        [TestMethod]
        public void FullElevationTest()
        {
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 200));

            Assert.AreEqual(201.0, track.FullElevation);
            Assert.AreEqual(201.0, track.FullElevation);

        }

        [TestMethod]
        public void FullDecreseTest()
        {
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 200));

            Assert.AreEqual(124.0, track.FullDecrease);

        }

        [TestMethod]
        public void CalculateDistanceTest()
        {
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));
            Assert.AreEqual(13611579.62661, track.CalculateDistance());
        }

        [TestMethod]
        public void FindMinimumCoordinateTest()
        {

            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            Assert.AreEqual(-12.5, track.FindMinimumCoordinate().Latitude);
            Assert.AreEqual(-42.789, track.FindMinimumCoordinate().Longitude);

        }

        [TestMethod]
        public void FindMaximumCoordinateTest()
        {
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            Assert.AreEqual(13.7, track.FindMaximumCoordinate().Latitude);
            Assert.AreEqual(45.7, track.FindMaximumCoordinate().Longitude);
        }

        [TestMethod]
        public void TestRectangleArea()
        {
            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            Assert.AreEqual(2318.4118, track.RectangleArea);
        }
    }
}
