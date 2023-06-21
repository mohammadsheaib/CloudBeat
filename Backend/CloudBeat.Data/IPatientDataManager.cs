using CloudBeat.Entities;

namespace CloudBeat.Data
{
    public interface IPatientDataManager
    {
        List<PatientDetail> GetPatientsDetails(int pageNumber, int pageSize);
        Patient GetPatient(long patientId);
    }
}