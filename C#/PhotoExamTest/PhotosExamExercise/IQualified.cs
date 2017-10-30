using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosExamExercise
{
    public interface IQualified
    {
        QualityLevel Quality { get; set; }
    }
}
