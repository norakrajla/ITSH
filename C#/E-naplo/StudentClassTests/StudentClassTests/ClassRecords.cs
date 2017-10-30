using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    public class ClassRecords
    {
        public string ClassName { get; set; }

        public ClassRecords(string className)
        {
            this.ClassName = className;
        }

        private List<Student> students = new List<Student>();



        public bool AddStudent(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == student.Name)
                {
                    return false;
                }
            }
            students.Add(student);
            return true;
        }

        public bool RemoveStudent(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == student.Name)
                {
                    return true;
                }
            }
            students.Remove(student);
            return false;
        }

        public double CalculateClassAverage()
        {
            double classAtlag = 0.0;
            if (students.Count < 1)
            {
                throw new ArithmeticException();
            }
            
            if (students.Count > 0)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].CalculateAverage() == 0)
                    { throw new ArithmeticException(); }

                    classAtlag += students[i].CalculateAverage();
                }
                classAtlag /= students.Count;
                classAtlag = Math.Round(classAtlag, 2);
            }
            return classAtlag;
        }

        public double CalculateClassAverageBySubject(Subject subject)
        {
            double classAtlagBySubject = 0.0;
            int osztoSzamlalo = 0;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].CalculateSubjectAverage(subject) != 0)
                {
                    classAtlagBySubject += students[i].CalculateSubjectAverage(subject);
                    osztoSzamlalo++;
                }
            }
            classAtlagBySubject /= osztoSzamlalo;
            classAtlagBySubject = Math.Round(classAtlagBySubject, 2);


            return classAtlagBySubject;
        }

        public Student FindStudentByName(string name)
        {
            if (name == "")
            { throw new ArgumentException(); }

            if (students.Count < 1)
            { throw new InvalidOperationException(); }

            Student talaltStudent = null;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name)
                {
                    talaltStudent = students[i];
                }
            }
            if (talaltStudent == null)
            { throw new ArgumentException(); }

            return talaltStudent;
        }


        public Student GetStudentByNameOrNull(string name)
        {
            Student talaltStudent = null;

            return talaltStudent;
        }

        public string ListStudentNames()
        {
            string tanulokListaja = "";

            for (int i = 0; i < students.Count; i++)
            {
                tanulokListaja += students[i].Name + ", ";
            }

            return tanulokListaja.Remove(tanulokListaja.Length - 2, 2);
        }


        public List<StudyResultEntry> ListStudentResults()        {
            if (students.Count < 1)
            { throw new InvalidOperationException(); }

            List<StudyResultEntry> results = new List<StudyResultEntry>();

            for (int i = 0; i < students.Count; i++)
            {
                StudyResultEntry studyResultEntry = new StudyResultEntry(students[i].CalculateAverage(), students[i].Name);
                results.Add(studyResultEntry);
            }
            
            return results;
        }
    }
}
