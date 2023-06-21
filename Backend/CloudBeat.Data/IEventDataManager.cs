using CloudBeat.Entities;

namespace CloudBeat.Data
{
    public interface IEventDataManager
    {
        List<Event> GetPatientEvents(long patientId);
    }
}