using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosExamExercise
{
    public class PhotoCollection
    {
        public List<Photo> Photos = new List<Photo>();

        private int numberOfStars;
        public int NumberOfStars
        {
            get
            {
                for (int i = 0; i < Photos.Count; i++)
                {
                    if (Photos[i].Quality == QualityLevel.NO_STAR)
                    {
                        numberOfStars += 0;
                    }
                    else if (Photos[i].Quality == QualityLevel.ONE_STAR)
                    {
                        numberOfStars += 1;
                    }
                    else  
                    {
                        numberOfStars += 2;
                    }
                }
                return numberOfStars;
            }
            set { }
        }


        public void AddPhoto(params string[] newPhotos)
        {
            for (int i = 0; i < newPhotos.Length; i++)
            {
                Photos.Add(new Photo(newPhotos[i]));
            }
        }


        public void GiveStars(string name, QualityLevel quality)
        {
            bool IsFound = false;

            foreach (Photo photo in Photos)
            {
                if (photo.Name == name)
                {
                    photo.Quality = quality;
                    IsFound = true;
                }
            }

            if (IsFound == false)
            { throw new PhotoNotFoundException(); }
        }

        public string GetPhotoListGroupedByStars()
        {
      
            StringBuilder resultSB = new StringBuilder();

            string result = "";

            resultSB.AppendLine("No Star");

            for (int i = 0; i < Photos.Count; i++)
            {
                if (Photos[i].Quality == QualityLevel.NO_STAR)
                {
                    resultSB.AppendLine(Photos[i].Name);
                }
            }
            resultSB.AppendLine("One Star");
            for (int i = 0; i < Photos.Count; i++)
            {
                if (Photos[i].Quality == QualityLevel.ONE_STAR)
                {
                    resultSB.AppendLine(Photos[i].Name);
                }
            }
            resultSB.AppendLine("Two Stars");
            for (int i = 0; i < Photos.Count; i++)
            {
                if (Photos[i].Quality == QualityLevel.TWO_STAR)
                {
                    resultSB.AppendLine(Photos[i].Name);
                }
            }

            result = resultSB.ToString();

            return result;
        }
       

    }
}
