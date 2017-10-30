using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
    public class ActivitiesManager
    {

        public ActivitiesManager(List<IActivity> activityList)
        {
            this.ActivityList = activityList;
        }


        List<IActivity> ActivityList { get; set; }

        //private int numberOfTrackActivities;
        public int NumberOfTrackActivities
        {


            get
            {
                return ActivityList.Where(x => x is ActivityWithTrack).Count();

                //for (int i = 0; i < activityList.Count; i++)
                //{
                //    if (activityList[i].TypeOfActivity == ActivityType.BIKING
                //        || activityList[i].TypeOfActivity == ActivityType.HIKING
                //        || activityList[i].TypeOfActivity == ActivityType.RUNNING)
                //    {
                //        numberOfTrackActivities++;
                //    }
                //}
                //return numberOfTrackActivities;
            }
        }

       // private int numberOfWithoutTrackActivities;
        public int NumberOfWithoutTrackActivities
        {
            get
            {
                return ActivityList.Where(x => x is ActivityWithoutTrack).Count();


                //for (int i = 0; i < activityList.Count; i++)
                //{
                //    if (activityList[i].TypeOfActivity == ActivityType.BASKETBALL)                 
                //    {
                //        numberOfWithoutTrackActivities++;
                //    }
                //}
                //return numberOfWithoutTrackActivities;
            }
        }

        private List<Report> distancesByTypes = new List<Report>();
        public List<Report> DistancesByTypes
        {
            get
            {
                var result = ActivityList.GroupBy(x => x.TypeOfActivity)
                          .Select(x => new { TypeOfActivity = x.Key, Osszeg = x.Sum(y => y.CalculateDistance()) });

                foreach (var item in result)
                {
                    distancesByTypes.Add(new Report(item.TypeOfActivity, item.Osszeg));
                }
                return distancesByTypes;
            }
        }

      

    }
}
