using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityProject.Exercises
{
    public class Track
    {
        public List<TrackPoint> TrackPoints = new List<TrackPoint>();

        private double fullElevation;
        public double FullElevation {
            get
            {
                fullElevation = 0;

                double ElevationOfTrackpoint = TrackPoints[0].Elevation;   // ő a korábbi elem
                foreach (TrackPoint trackpoint in TrackPoints)
                {
                    if (trackpoint.Elevation > ElevationOfTrackpoint)
                    {
                        fullElevation += trackpoint.Elevation - ElevationOfTrackpoint ;
                    }
                    ElevationOfTrackpoint = trackpoint.Elevation;
                }


                //for (int i = 0; i < TrackPoints.Count - 1; i++)
                //{
                //    double kulonbseg = TrackPoints[i + 1].Elevation - TrackPoints[i].Elevation;
                //    if (kulonbseg > 0)
                //    {
                //        fullElevation += kulonbseg;
                //    }
                //}
                return fullElevation;
            }
        }

        private double fullDecrease;
        public double FullDecrease
        {
            get
            {
                fullDecrease = 0;
                for (int i = 0; i < TrackPoints.Count - 1; i++)
                {
                    double kulonbseg = TrackPoints[i + 1].Elevation - TrackPoints[i].Elevation;
                    if (kulonbseg < 0)
                    {
                        fullDecrease += kulonbseg;
                    }
                }
                return Math.Abs(fullDecrease);
            }
        }

        public double RectangleArea
        {
            get
            {
                return (FindMaximumCoordinate().Longitude - FindMinimumCoordinate().Longitude)
               * (FindMaximumCoordinate().Latitude - FindMinimumCoordinate().Latitude);
            }
        }
       

        public void AddTrackPoint(TrackPoint point)
        {
            TrackPoints.Add(point);
        }

        public double CalculateDistance()
        {
            double result = 0;
            for (int i = 0; i < TrackPoints.Count - 1; i++)
            {
                result += TrackPoints[i].CalculateDistanceFrom(TrackPoints[i + 1]);
            }

            return result;
        }


        public Coordinate FindMinimumCoordinate()
        {
            if (TrackPoints == null || TrackPoints.Count == 0)
            {
                throw new NullReferenceException("TrackPoints lista nem létezi vagy üres");
            }

            //double minLat = 90;     //  // TrackPoints[0].Coordinate.Latitude    
            //double minLong = 180;  // TrackPoints[0].Coordinate.Longitude

            double minLatitude = TrackPoints.OrderBy(x => x.Coordinate.Latitude).Select(x => x.Coordinate.Latitude).FirstOrDefault();
            double minLongitude = TrackPoints.OrderBy(x => x.Coordinate.Longitude).Select(x => x.Coordinate.Longitude).FirstOrDefault();


            //for (int i = 0; i < TrackPoints.Count; i++)
            //{
            //    if (TrackPoints[i].Coordinate.Latitude < minLat)
            //    {
            //        minLat = TrackPoints[i].Coordinate.Latitude;
            //    }
            //}

            //for (int i = 0; i < TrackPoints.Count; i++)
            //{
            //    if (TrackPoints[i].Coordinate.Longitude < minLong)
            //    {
            //        minLong = TrackPoints[i].Coordinate.Longitude;
            //    }
            //}

            Coordinate result = new Coordinate(minLatitude, minLongitude);
            return result;
        }

        public Coordinate FindMaximumCoordinate()
        {
            if (TrackPoints == null || TrackPoints.Count == 0)
            {
                throw new NullReferenceException("TrackPoints lista nem létezi vagy üres");
            }

           // double maxLat = -90;
            //double maxLong = -180;

            double maxLatitude = TrackPoints.OrderByDescending(x => x.Coordinate.Latitude).Select(x => x.Coordinate.Latitude).FirstOrDefault();
            double maxLongitude = TrackPoints.OrderByDescending(x => x.Coordinate.Longitude).Select(x => x.Coordinate.Longitude).FirstOrDefault();


            //for (int i = 0; i < TrackPoints.Count; i++)
            //{
            //    if (TrackPoints[i].Coordinate.Latitude > maxLat)
            //    {
            //        maxLat = TrackPoints[i].Coordinate.Latitude;
            //    }
            //}

            //for (int i = 0; i < TrackPoints.Count; i++)
            //{
            //    if (TrackPoints[i].Coordinate.Longitude > maxLong)
            //    {
            //        maxLong = TrackPoints[i].Coordinate.Longitude;
            //    }
            //}

            Coordinate result = new Coordinate(maxLatitude, maxLongitude);
            return result;
        }

      
    }
}
