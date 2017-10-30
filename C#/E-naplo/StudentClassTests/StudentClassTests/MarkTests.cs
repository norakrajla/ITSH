

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentClass;

namespace StudentClassTests
{
    [TestClass]
    public class MarkTests
    {
        private Subject testMathSubject = new Subject("matematika");

       
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullParameterShouldThrowException()
        {
            new Mark(5, null);
        }

        [TestMethod]       
        public void TestCreate()
        {
           Mark mark = new Mark(5, testMathSubject);
            Assert.AreEqual(mark.Grade, 5);
            Assert.AreEqual(mark.Subject, testMathSubject);
            Assert.AreEqual(mark.ToString(), "excellent(5)");
        }        
    }
}

