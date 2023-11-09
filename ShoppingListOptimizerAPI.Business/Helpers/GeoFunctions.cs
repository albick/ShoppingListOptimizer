using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.Helpers
{
    public static class GeoFunctions
    {
        public static double CalculateDistance(double longitudeA, double latitudeA, double longitudeB, double latitudeB)
        {
            // Convert degrees to radians
            double radLongitudeA = ToRadians(longitudeA);
            double radLatitudeA = ToRadians(latitudeA);
            double radLongitudeB = ToRadians(longitudeB);
            double radLatitudeB = ToRadians(latitudeB);

            // Calculate differences in coordinates
            double deltaLongitude = radLongitudeB - radLongitudeA;
            double deltaLatitude = radLatitudeB - radLatitudeA;

            // Haversine formula
            double a = Math.Pow(Math.Sin(deltaLatitude / 2), 2) +
                       Math.Cos(radLatitudeA) * Math.Cos(radLatitudeB) *
                       Math.Pow(Math.Sin(deltaLongitude / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculate distance
            double distance = 6371 * c;

            return distance;
        }
        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
