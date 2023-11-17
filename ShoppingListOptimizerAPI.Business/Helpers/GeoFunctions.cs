using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.Helpers
{
    public static class GeoFunctions
    {
       private const double EarthRadiusKm = 6371.0;

        public static double CalculateDistance(Double point1lat, Double point1lon, Double point2lat, Double point2lon)
        {
            var dLat = DegreeToRadian(point2lat - point1lat);
            var dLon = DegreeToRadian(point2lon - point1lon);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreeToRadian(point1lat)) * Math.Cos(DegreeToRadian(point2lat)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = EarthRadiusKm * c;
            return distance;
        }

        private static double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }
    }
}
