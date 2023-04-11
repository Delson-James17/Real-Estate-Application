using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Data;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly RealEstateDbContext _context;
        public AppointmentsController(RealEstateDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var appointment = await _context.Appointment.ToArrayAsync();
            return Ok(appointment);
        }
    }
}
