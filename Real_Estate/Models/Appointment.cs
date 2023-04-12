using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Email {get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }
      

        public int? PropertyId { get; set; }
        public EstateProperty? Property { get; set; }
       [DataType(DataType.DateTime)]
        [Required]
        public DateTime? DateofAppointment { get; set; }
       
       
      
    }
}
