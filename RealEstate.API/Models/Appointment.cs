using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email {get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
      
        /*
        public int? PropertyId { get; set; }
        public EstateProperty? Property { get; set; }*/
       [DataType(DataType.DateTime)]
        [Required]
        public DateTime? DateofAppointment { get; set; }
        public Appointment()
        {

        }
        public Appointment(string id, string name, string? email, string? phone, string? address, DateTime? dateofAppointment)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            DateofAppointment = dateofAppointment;
        }
    }
}
