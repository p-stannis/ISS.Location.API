using System.ComponentModel.DataAnnotations;

namespace ISS.Location.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
