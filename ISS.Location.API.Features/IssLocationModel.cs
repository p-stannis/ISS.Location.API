using System;
using System.Text.Json.Serialization;

namespace ISS.Location.API.Features
{
    public class IssLocationModel
    {
        public IssPosition IssPosition { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class IssPosition
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
