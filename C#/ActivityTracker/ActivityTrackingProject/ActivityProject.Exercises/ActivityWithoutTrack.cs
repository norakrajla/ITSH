using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
    public class ActivityWithoutTrack: IActivity
    {
        public ActivityType TypeOfActivity { get; set; }

        public ActivityWithoutTrack(ActivityType typeOfActivity)
        {
            TypeOfActivity = typeOfActivity;
        }

        public double CalculateDistance()
        {
            return 0;
        }

    }
}
