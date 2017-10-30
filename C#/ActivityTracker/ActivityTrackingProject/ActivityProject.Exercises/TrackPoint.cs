using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
   public class TrackPoint
    {
        public double Elevation { get; set; }
        public Coordinate Coordinate { get; set; }

        public TrackPoint(Coordinate coordinate, double elevation)
        {
            Elevation = elevation;
            Coordinate = coordinate;
        }

       public double CalculateDistanceFrom(TrackPoint trackPoint)
        {
            const int radiusOfEarth = 6371;
            double thisLatitude = Coordinate.Latitude;
            double thisLongitude = Coordinate.Longitude;
            double otherLatitude = trackPoint.Coordinate.Latitude;
            double otherLongitude = trackPoint.Coordinate.Longitude;
            Double latitudeDistance = (Math.PI * (otherLatitude - thisLatitude)) / 180.0;
            Double longitudeDistance = (Math.PI * (otherLongitude - thisLongitude)) / 180.0;
            Double a = Math.Sin(latitudeDistance / 2) * Math.Sin(latitudeDistance / 2)
            + Math.Cos((Math.PI * (thisLatitude)) / 180.0) * Math.Cos((Math.PI * (otherLatitude)) / 180.0)
            * Math.Sin(longitudeDistance / 2) * Math.Sin(longitudeDistance / 2);
            Double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radiusOfEarth * c * 1000;
            double height = Elevation - trackPoint.Elevation;
            distance = Math.Pow(distance, 2) + Math.Pow(height, 2);
            return Math.Round(Math.Sqrt(distance), 5);
        }

    }
}
