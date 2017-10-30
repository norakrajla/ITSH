using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
   public class Coordinate
    {
       
        // Latitude: [-90,90] , Longitude:  [-180,180] 


        private double latitude;
        public double Latitude {
            get { return latitude; }
            protected set
            {
                if (value >= -90 && value <= 90)
                {
                    latitude = value;
                }
                else
                { throw new ArgumentException(); }
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            protected set
            {
                if (value >= -180 && value <= 180)
                {
                    longitude = value;
                }
                else
                { throw new ArgumentException(); }
            }
        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
