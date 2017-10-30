using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotosExamExercise;
using System.Text;

namespace PhotosExamTests
{
    [TestClass]
    public class PhotoTests
    {
        [TestMethod]
        public void TestPhoto()
        {
            Photo photo = new Photo("aaa.jpg");
            Assert.AreEqual("aaa.jpg", photo.Name);
            Assert.AreEqual(QualityLevel.NO_STAR, photo.Quality);
        }

        [TestMethod]
        public void TestIsStarable()
        {
            IQualified qualified = new Photo("a.jpg");
            Assert.IsInstanceOfType(qualified, typeof(IQualified));
        }

        [TestMethod]
        public void TestCreatePhotoWithStar()
        {
            Photo photo = new Photo("a.jpg", QualityLevel.ONE_STAR);
            Assert.AreEqual("a.jpg", photo.Name);
            Assert.AreEqual(QualityLevel.ONE_STAR, photo.Quality);
        }

        [TestMethod]
        public void TestSetQuality()
        {
            Photo photo = new Photo("b.jpg");
            Assert.AreEqual("b.jpg", photo.Name);
            Assert.AreEqual(QualityLevel.NO_STAR, photo.Quality);

            photo.Quality = QualityLevel.ONE_STAR;
            Assert.AreEqual(QualityLevel.ONE_STAR, photo.Quality);
        }

        [TestMethod]
        public void TestCreatePhotoCollection()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            Assert.AreEqual(photoCollection.Photos.Count, 0);
        }

        [TestMethod]
        public void TestStarsEmpty()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            photoCollection.AddPhoto("a.jpg", "b.jpg", "c.jpg");
            Assert.AreEqual(0, photoCollection.NumberOfStars);
        }

        [TestMethod]
        [ExpectedException(typeof(PhotoNotFoundException))]
        public void TestNotFound()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            photoCollection.AddPhoto("a.jpg", "b.jpg", "c.jpg");
            photoCollection.GiveStars("d.jpg", QualityLevel.ONE_STAR);
        }

        [TestMethod]
        public void TestStars()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            photoCollection.AddPhoto("a.jpg", "b.jpg", "c.jpg");
            photoCollection.GiveStars("a.jpg", QualityLevel.TWO_STAR);
            photoCollection.GiveStars("a.jpg", QualityLevel.ONE_STAR);
            Assert.AreEqual(1, photoCollection.NumberOfStars);
        }

        [TestMethod]
        public void TestStarsThree()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            photoCollection.AddPhoto("a.jpg", "b.jpg", "c.jpg", "d.jpg", "e.jpg");
            photoCollection.GiveStars("a.jpg", QualityLevel.ONE_STAR);
            photoCollection.GiveStars("b.jpg", QualityLevel.TWO_STAR);
            Assert.AreEqual(3, photoCollection.NumberOfStars);
        }

        [TestMethod]
        public void TestStarsGroups()
        {
            PhotoCollection photoCollection = new PhotoCollection();
            photoCollection.AddPhoto("a.jpg", "b.jpg", "c.jpg", "d.jpg", "e.jpg");
            photoCollection.GiveStars("a.jpg", QualityLevel.ONE_STAR);
            photoCollection.GiveStars("b.jpg", QualityLevel.TWO_STAR);
            photoCollection.GiveStars("c.jpg", QualityLevel.TWO_STAR);
            photoCollection.GiveStars("d.jpg", QualityLevel.NO_STAR);
            photoCollection.GiveStars("e.jpg", QualityLevel.ONE_STAR);
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("No Star");
            expected.AppendLine("d.jpg");
            expected.AppendLine("One Star");
            expected.AppendLine("a.jpg");
            expected.AppendLine("e.jpg");
            expected.AppendLine("Two Stars");
            expected.AppendLine("b.jpg");
            expected.AppendLine("c.jpg");
            Assert.AreEqual(expected.ToString(), photoCollection.GetPhotoListGroupedByStars());
        }

    }
}
