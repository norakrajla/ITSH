using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentClass;
using System.Collections;
using System.Collections.Generic;

namespace StudentClassTests
{
    [TestClass]
    public class ClassRecordsTests
    {

        private ClassRecords classRecords;
        
        [TestInitialize]
        public void Init()
        {
            classRecords = new ClassRecords("Fourth Grade A");
            Student firstStudent = new Student("Kovács Rita");
            Student secondStudent = new Student("Nagy Béla");
            Student thirdStudent = new Student("Varga Márton");
            firstStudent.AddGrade(5, new Subject("földrajz"));
            firstStudent.AddGrade(3, new Subject("matematika"));
            firstStudent.AddGrade(2, new Subject("földrajz"));
            secondStudent.AddGrade(5, new Subject("biológia"));
            secondStudent.AddGrade(3, new Subject("matematika"));
            secondStudent.AddGrade(2, new Subject("zene"));
            thirdStudent.AddGrade(5, new Subject("fizika"));
            thirdStudent.AddGrade(3, new Subject("kémia"));
            thirdStudent.AddGrade(2, new Subject("földrajz"));
            classRecords.AddStudent(firstStudent);
            classRecords.AddStudent(secondStudent);
            classRecords.AddStudent(thirdStudent);
        }

     

                [TestMethod]
                public void TestCreate()
                {
                    Assert.AreEqual(classRecords.ClassName, "Fourth Grade A");
                }
        
             [TestMethod]
             public void TestAddStudentAlreadyExists()
             {
                 Assert.IsFalse(classRecords.AddStudent(new Student("Nagy Béla")));
             }
        
             [TestMethod]
             public void TestAddStudent()
             {
                 Assert.IsTrue(classRecords.AddStudent(new Student("Nagy Klára")));
             }
        
             [TestMethod]
             public void TestRemoveStudent()
             {
                 Assert.IsTrue(classRecords.RemoveStudent(new Student("Nagy Béla")));
             }
        
             [TestMethod]
             public void TestRemoveStudentDoesNotExists()
             {
                 Assert.IsFalse(classRecords.RemoveStudent(new Student("Nagy Klára")));
             }
        
             [TestMethod]
             [ExpectedException(typeof(ArithmeticException))]
             public void EmptyStudentListShouldThrowException()
             {
                 new ClassRecords("First Grade").CalculateClassAverage();
             }
        
             [TestMethod]
             [ExpectedException(typeof(ArithmeticException))]
             public void NoMarksShouldThrowException()
             {
                 ClassRecords classRecords = new ClassRecords("First Grade");
                 classRecords.AddStudent(new Student("Nagy Béla"));
                 classRecords.CalculateClassAverage();
             }

        [TestMethod]
             public void TestCalculateClassAverage()
             {
                 Assert.AreEqual(classRecords.CalculateClassAverage(), 3.33);
             }
       
             [TestMethod]
             public void TestCalculateClassAverageBySubject()
             {
                 Subject geography = new Subject("földrajz");
                 Assert.AreEqual(classRecords.CalculateClassAverageBySubject(geography), 2.75);
             }
        
                    [TestMethod]
                    [ExpectedException(typeof(ArgumentException))]
                    public void EmptyStudentNameShouldThrowException()
                    {
                        classRecords.FindStudentByName("");
                    }
       
                    [TestMethod]
                    [ExpectedException(typeof(InvalidOperationException))]
                    public void EmptyListShouldThrowException()
                    {

                        new ClassRecords("First Grade").FindStudentByName("Kovács Rita");
                    }
                            [TestMethod]
                    [ExpectedException(typeof(ArgumentException))]
                    public void NonExistingStudentShouldThrowException()
                    {

                        classRecords.FindStudentByName("Kiss Rita");
                    }
                    
        [TestMethod]
                    public void testFindStudentByName()
                    {
                        Assert.AreEqual(classRecords.FindStudentByName("Kovács Rita").Name, "Kovács Rita");
                    }

        

                    [TestMethod]
                    [ExpectedException(typeof(InvalidOperationException))]
                    public void EmptyListThrowsException()
                    {
                        new ClassRecords("Fourth Grade").ListStudentResults();
                    }

                    [TestMethod]
                    public void testListStudyResults()
                    {         
                        List<StudyResultEntry> list = classRecords.ListStudentResults();
                        StudyResultEntry firstEntry = list[0] as StudyResultEntry;
                        Assert.AreEqual(firstEntry.StudentName, "Kovács Rita");
                        Assert.AreEqual(firstEntry.StudyAverage, 3.33);

                    }

                    [TestMethod]
                    public void TestListStudentNames()
                    {
                        Assert.AreEqual(classRecords.ListStudentNames(), "Kovács Rita, Nagy Béla, Varga Márton");
                    }
    }
}
