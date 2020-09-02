using System;
using System.Collections.Generic;
using System.Text;

namespace RailtownBE5Assignment.Models
{
    public class GeoLocationResult
    {
        public IUser UserOne { get;set; }
        public IUser UserTwo { get; set; }

        public double Distance { get; set; }

        public DateTime CaptureDateTime { get; set; }
    }
}
