using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentClass;

namespace StudentClassTests
{
    [TestClass]
    public class StudentsTests
    {
        private Subject testMathSubject = new Subject("matematika");
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyNameShouldThrowException()
        {
            new Student("");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSubjectInGradingShouldThrowException()
        {
            new Student("Kovács").AddGrade(5, null);
        }
        
        [TestMethod]
        public void TestAddGrade()
        {
            Student student = new Student("Kovács");
            student.AddGrade(5, testMathSubject);
            
            Assert.AreEqual(student.ToString(), "Kovács marks: matematika: excellent(5)");
        }

       [TestMethod]
        public void TestCalculateAverage()
        {
            Student student = new Student("Kovács");
           
            student.AddGrade(5, testMathSubject);
            student.AddGrade(3, testMathSubject);
            student.AddGrade(2, testMathSubject);
          
            Assert.AreEqual(student.CalculateAverage(), 3.33);
        }
        
        [TestMethod]
        public void TestCalculateAverageIfMarksEmpty()
        {
            Student student = new Student("Kovács");            
            Assert.AreEqual(student.CalculateAverage(), 0.0);
        }
        
                [TestMethod]       
                public void TestCalculateSubjectAverage()
                {
                    Student student = new Student("Kovács");
                    student.AddGrade(5, testMathSubject);
                    student.AddGrade(3, new Subject("történelem"));
                    student.AddGrade(4, testMathSubject);           
                    Assert.AreEqual(student.CalculateSubjectAverage(testMathSubject), 4.5);
                }
        
                [TestMethod]       
                public void TestCalculateSubjectAverageIfMarksEmpty()
                {
                    Student student = new Student("Kovács");

                    Assert.AreEqual(student.CalculateSubjectAverage(testMathSubject), 0.0);
                }
        
                [TestMethod]
                public void TestCalculateSubjectAverageIfNoMarkFromSubject()
                {
                    Student student = new Student("Kovács");

                    student.AddGrade(5, testMathSubject);
                    student.AddGrade(3, new Subject("történelem"));
                    student.AddGrade(4, testMathSubject);

                    Assert.AreEqual(student.CalculateSubjectAverage(new Subject("földrajz")), 0.0);
                }
    }
}
