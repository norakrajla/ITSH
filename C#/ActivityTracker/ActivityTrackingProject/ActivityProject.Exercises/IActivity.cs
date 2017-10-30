using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
    public interface IActivity
    {
        double CalculateDistance();

        ActivityType TypeOfActivity { get; set; }
    }
}
