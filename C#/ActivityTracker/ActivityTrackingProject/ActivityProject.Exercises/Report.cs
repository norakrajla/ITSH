using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
   public class Report
    {
       
        public ActivityType ActivityType { get; set; }
        public double Distance { get; set; }

        public Report(ActivityType activityType, double distance)
        {
            ActivityType = activityType;
            Distance = distance;
        }
    }
}
