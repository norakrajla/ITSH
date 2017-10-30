using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
   public class ActivityWithTrack: IActivity
    {

        public ActivityType TypeOfActivity { get; set; }
        public Track Track { get; set; }

        public ActivityWithTrack(Track track, ActivityType typeOfActivity)
        {
            TypeOfActivity = typeOfActivity;
            Track = track;
        }

        public double CalculateDistance()
        {
            return Track.CalculateDistance();
        }

        
    }
}
