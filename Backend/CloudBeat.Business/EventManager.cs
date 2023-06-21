using CloudBeat.Data;
using CloudBeat.Entities;
using CloudBeat.Framework;
namespace CloudBeat.Business
{
    public class EventManager
    {
        IEventDataManager _eventDataManager;
        public EventManager(IEventDataManager eventDataManager)
        {
            _eventDataManager = eventDataManager;
        }
        public List<EventDetail> GetPatientEventDetails(long patientId)
        {
            List<Event> events = _eventDataManager.GetPatientEvents(patientId);
            if (events.IsNullOrEmpty())
                return null;

            return events.MapRecords(e => new EventDetail()
            {
                BPM = e.BPM,
                Date = e.Date.ToString("yyyy-MM-dd mm:HH:ss")   
            }).ToList();
        }
    }
}
