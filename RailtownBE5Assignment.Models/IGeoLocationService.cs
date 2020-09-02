using System;
using System.Collections.Generic;
using System.Text;

namespace RailtownBE5Assignment.Models
{
    /// <summary>
    /// Service to manipulate user data
    /// </summary>
    public interface IGeoLocationService
    {
        public GeoLocationResult GetFarthestUsers(IUser[] users);
    }
}
