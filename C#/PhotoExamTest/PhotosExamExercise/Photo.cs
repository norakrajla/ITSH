using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosExamExercise
{
    public enum QualityLevel { NO_STAR, ONE_STAR, TWO_STAR }

    public class Photo : IQualified
    {

        public string Name { get; set; }
        public QualityLevel Quality { get; set; }

        public Photo(string name)
        {
            Name = name;
        }

        public Photo(string name, QualityLevel quality)
        {
            Name = name;
            Quality = quality;
        }

       


    }
}
