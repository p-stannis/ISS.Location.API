using System;
using System.Text.Json.Serialization;

namespace ISS.Location.API.Entities
{
    public class IssLocationApi
    {
        [JsonPropertyName("iss_position")]
        public IssPosition IssPosition { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TimeStamp { get; set; }
    }
}
