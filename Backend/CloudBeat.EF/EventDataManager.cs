using CloudBeat.Data;
using CloudBeat.Entities;

namespace CloudBeat.EF
{
    public class EventDataManager : IEventDataManager
    {
        CloudBeatDBContextClass _dbContext;
        public EventDataManager(CloudBeatDBContextClass dBContext)
        {
            _dbContext = dBContext;
        }

        public List<Event> GetPatientEvents(long patientId)
        {
            return _dbContext.Events.Where(e=>e.PatientId== patientId).ToList();
        }
    }
}