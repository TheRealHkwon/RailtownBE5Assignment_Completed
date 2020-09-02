using System;
using System.Collections.Generic;
using System.Text;

namespace RailtownBE5Assignment.Models
{
    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public GeoLocation Geo { get; set; }

        public string GetFriendlyAddress()
        {
            return $"{Suite}-{Street}, {City} {Zipcode}";
        }
    }
}
