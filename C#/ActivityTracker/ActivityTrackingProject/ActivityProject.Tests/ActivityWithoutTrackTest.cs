using ActivityProject.Exercises;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivityProject.Tests
{

    [TestClass]
    public class ActivityWithoutTrackTest
    {
        ActivityWithoutTrack activityWithoutTrack = new ActivityWithoutTrack(ActivityType.BASKETBALL);

        [TestMethod]
        public void CalculateDistanceTest()
        {
            Assert.AreEqual(0, activityWithoutTrack.CalculateDistance());
        }
        [TestMethod]
        public void GetTypeOfActivityTest()
        {
            Assert.AreEqual(ActivityType.BASKETBALL, activityWithoutTrack.TypeOfActivity);
        }
    }
}
