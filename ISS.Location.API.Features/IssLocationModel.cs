using ISS.Location.API.Entities;
using System;

namespace ISS.Location.API.Features
{
    public class IssLocationModel
    {
        public int Id { get; set; }
        public IssPosition IssPosition { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
