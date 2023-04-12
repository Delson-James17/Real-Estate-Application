using Real_Estate.Models;

namespace Real_Estate.ViewModels
{
    public class AppointmentViewModel
    {
      public Appointment Appointment { get; set; }

        public List<EventModel> Events { get; set; }
        public class EventModel
        {
            public string Title { get; set; }
            public string Start { get; set; }
            
            public bool AllDay { get; set; }= true;
        }
    }
}
