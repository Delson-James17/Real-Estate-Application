using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.DTO
{
    public class AppointmentDto
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        /*
        public int? PropertyId { get; set; }
        public EstateProperty? Property { get; set; }*/
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime? DateofAppointment { get; set; }
    }
}
