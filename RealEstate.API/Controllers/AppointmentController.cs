using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTO;
using RealEstate.API.Models;
using RealEstate.API.Repository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {

            return Ok(await _appointmentRepository.GetAllAppointment());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppointmentById(string id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        [HttpPost]
        public  IActionResult CreateAppointment(AppointmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newAppointment = new Appointment
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DateofAppointment = dto.DateofAppointment
            };
            var appointment =  _appointmentRepository.AddAppointment(newAppointment);
            return Ok(appointment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(string id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.GetAppointmentById(appointment.Id);

            return Ok(appointment);
        }

        [HttpPost("{id}")]
        public IActionResult EditEstateProperty(string id, AppointmentDto dto)
        {
            var appointment = _appointmentRepository.GetAppointmentById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newAppointment = new Appointment
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DateofAppointment = dto.DateofAppointment
            };
            var appointmentToReturn =  _appointmentRepository.AddAppointment(newAppointment);
            return Ok(appointmentToReturn);

        }
    }

}
