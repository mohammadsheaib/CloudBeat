using CloudBeat.Data;
using CloudBeat.Entities;

namespace CloudBeat.Business
{
    public class PatientManager
    {
        IPatientDataManager _patientDataManager;
        EventManager _eventManager;
        public PatientManager(IPatientDataManager patientDataManager, EventManager eventManager)
        {
            _patientDataManager = patientDataManager;
            _eventManager = eventManager;
        }
        public List<PatientDetail> GetPatientsDetails(int pageNumber, int pageSize)
        {
            return _patientDataManager.GetPatientsDetails(pageNumber, pageSize);
        }

        public PatientEventsSummary GetPatientEventsSummary(long patientId)
        {
            List<EventDetail> patientEventDetails = _eventManager.GetPatientEventDetails(patientId);
            Patient patient = _patientDataManager.GetPatient(patientId);
         
            return new PatientEventsSummary()
            {
                EventDetails = patientEventDetails,
                MaxBPM = patientEventDetails.Max(e => e.BPM),
                MinBPM = patientEventDetails.Min(e => e.BPM),
                AverageBPM = (decimal)patientEventDetails.Average(e => e.BPM),
                PatientName = patient.Name
            };
        }
    }
}