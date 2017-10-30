using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    public class Student
    {

        public string Name { get; set; }

        public Student(string name)
        {
            if (name == "")
            {
                throw new ArgumentException("Nem írtad be a tanuló nevét!");
            }
            else
            {
                this.Name = name;
            }
        }

        private List<Mark> marks = new List<Mark>();



        public void AddGrade(int grade, Subject subject)
        {
            Mark jegy = new Mark(grade, subject);
            if (subject is null)
            {
                throw new ArgumentNullException("Nem írtad be a tanuló nevét!");
            }
            else
            {
                marks.Add(jegy);
            }
        }

        public double CalculateAverage()
        {
            double atlag = 0.0;
            if (marks.Count > 0)
            {
                for (int i = 0; i < marks.Count; i++)
                {
                    atlag += marks[i].Grade;
                }
                atlag /= marks.Count;
                atlag = Math.Round(atlag, 2);
            }
            return atlag;
        }

        public double CalculateSubjectAverage(Subject subject)
        {

            double subjectAtlag = 0.0;
            int osztoSzamlalo = 0;
            if (marks.Count > 0)
            {
                for (int i = 0; i < marks.Count; i++)
                {
                    if (marks[i].Subject.SubjectName == subject.SubjectName)
                    {
                        subjectAtlag += marks[i].Grade;
                        osztoSzamlalo++;
                    }
                }
                subjectAtlag /= osztoSzamlalo;
                subjectAtlag = Math.Round(subjectAtlag, 2);
            }
            if(osztoSzamlalo == 0)
            {
                subjectAtlag = 0.0;
            }
            
            return subjectAtlag;
        }

        public override string ToString()
        {
            string result = "";
            result = $"{this.Name} marks: ";
            for (int i = 0; i < marks.Count; i++)
            {
                result = $"{this.Name} marks: {marks[i].Subject.SubjectName}: {marks[i].ToString()}";
            }
            return result;
        }
    }
}
