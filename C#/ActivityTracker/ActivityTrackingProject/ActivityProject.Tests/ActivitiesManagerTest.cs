using ActivityProject.Exercises;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ActivityProject.Tests
{

    [TestClass]
    public class ActivitiesManagerTest
    {

        public Track track;

        List<IActivity> activityList;
        ActivitiesManager activitiesManager;

        public ActivitiesManagerTest()
        {
            track = new Track();
            activityList = new List<IActivity>()
             {
                new ActivityWithTrack(track, ActivityType.RUNNING),
                new ActivityWithoutTrack(ActivityType.BASKETBALL),
                new ActivityWithTrack(track, ActivityType.RUNNING)
             };

            activitiesManager = new ActivitiesManager(activityList);
        }


        [TestMethod]
        public void NumberWithTrackTest()
        {
            Assert.AreEqual(2, activitiesManager.NumberOfTrackActivities);
        }

        [TestMethod]
        public void NumberOfWithoutTrackTest()
        {
            Assert.AreEqual(1, activitiesManager.NumberOfWithoutTrackActivities);
        }

        [TestMethod]
        public void GetReportTypeTest()
        {
            List<Report> result = new List<Report>();

            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            result = activitiesManager.DistancesByTypes;

            Assert.IsTrue(result.Any(x => x.ActivityType == ActivityType.BASKETBALL));
            Assert.IsTrue(result.Any(x => x.ActivityType == ActivityType.RUNNING));
        }

        [TestMethod]
        public void GetReportDistanceTest()
        {
            List<Report> result = new List<Report>();

            track.AddTrackPoint(new TrackPoint(new Coordinate(12.5, 34.89), 123));
            track.AddTrackPoint(new TrackPoint(new Coordinate(-12.5, 45.7), 124));
            track.AddTrackPoint(new TrackPoint(new Coordinate(13.7, -6.0), 0));
            track.AddTrackPoint(new TrackPoint(new Coordinate(3.67, -42.789), 200));

            result = activitiesManager.DistancesByTypes;
            Assert.AreEqual(0, result.Single(x => x.ActivityType == ActivityType.BASKETBALL).Distance);
            Assert.AreEqual(2 * track.CalculateDistance(), result.Single(x => x.ActivityType == ActivityType.RUNNING).Distance);
        }
    }
}
