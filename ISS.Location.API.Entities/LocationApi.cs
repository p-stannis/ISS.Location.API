using System;
using System.Text.Json.Serialization;

namespace ISS.Location.API.Entities
{
    public class LocationApi
    {
        [JsonPropertyName("iss_position")]
        public IssPosition IssPosition { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TimeStamp { get; set; }
    }

    public class IssPosition
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
