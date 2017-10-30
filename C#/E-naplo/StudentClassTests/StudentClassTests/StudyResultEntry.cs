using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    public class StudyResultEntry
    {
        public string StudentName { get; set; }
        public double StudyAverage { get; set; }

        public StudyResultEntry(double studyAverage, string tanuloNeve)
        {
            this.StudentName = tanuloNeve;
            this.StudyAverage = studyAverage;
        }
    }
}
