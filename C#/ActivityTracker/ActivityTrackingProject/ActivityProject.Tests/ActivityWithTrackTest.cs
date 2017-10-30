using ActivityProject.Exercises;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivityProject.Tests
{

    [TestClass]
    public class ActivityWithTrackTest
    {

        Track track = new Track();


        [TestMethod]
        public void CalculateDistanceTest()
        {
            IActivity activityWithTrack = new ActivityWithTrack(track, ActivityType.RUNNING);

            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            Assert.AreEqual(13611579.62661, activityWithTrack.CalculateDistance());
        }

        [TestMethod]
        public void GetTypeOfActivityTest()
        {
            IActivity activityWithTrack = new ActivityWithTrack(track, ActivityType.RUNNING);

            Assert.AreEqual(ActivityType.RUNNING, activityWithTrack.TypeOfActivity);
        }
    }
}
