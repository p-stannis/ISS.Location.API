using System;
using System.ComponentModel.DataAnnotations;

namespace ISS.Location.API.Entities
{
    public class IssLocation : BaseEntity
    {
        [StringLength(50)]
        public string Latitude { get; set; }
        [StringLength(50)]
        public string Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
