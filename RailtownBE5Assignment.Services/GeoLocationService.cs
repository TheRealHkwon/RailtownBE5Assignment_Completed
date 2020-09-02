using RailtownBE5Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailtownBE5Assignment.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        /// <summary>
        /// Determines farthest distanced users by brute force.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public GeoLocationResult GetFarthestUsers(IUser[] users)
        {
            if (users.Length < 2)
            {
                throw new ArgumentOutOfRangeException("There are not enough users to determine a result.");
            }

            double maxDistance = 0;

            IUser user1 = users[0];
            IUser user2 = users[1];

            for (int i = 0; i<users.Length; i++)
            {
                for (int j = 0; j<users.Length; j++)
                {
                    double distance = CalculateDistance(users[i], users[j]);

                    if (distance > maxDistance)
                    {
                        user1 = users[i];
                        user2 = users[j];

                        maxDistance = distance;
                    }
                }    
            }

            return new GeoLocationResult 
            { 
                UserOne = user1,
                UserTwo = user2,
                Distance = maxDistance,
                CaptureDateTime = DateTime.UtcNow
            };
       }

        /// <summary>
        /// Calculates distance between 2 users, in kilometers.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        double CalculateDistance(IUser first, IUser second)
        {
            // from https://www.movable-type.co.uk/scripts/latlong.html

            int earthRadius = 6371;

            double lat1 = first.Address.Geo.Lat;
            double lat2 = second.Address.Geo.Lat;
            double long1 = first.Address.Geo.Lng;
            double long2 = second.Address.Geo.Lng;

            double phi1 = lat1 * Math.PI / 180;
            double phi2 = lat2 * Math.PI / 180;

            double deltaPhi = (lat2 - lat1) * Math.PI / 180;
            double deltaLambda = (long2 - long1) * Math.PI / 180;

            double a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                        Math.Cos(phi1) * Math.Cos(phi2) *
                        Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }
    }
}
