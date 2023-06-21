using CloudBeat.Data;
using CloudBeat.Entities;
using System.Data.Entity;

namespace CloudBeat.EF
{
    public class PatientDataManager : IPatientDataManager
    {
        CloudBeatDBContextClass _dbContext;
        public PatientDataManager(CloudBeatDBContextClass dBContext)
        {
            _dbContext = dBContext;
        }

        public List<PatientDetail> GetPatientsDetails(int pageNumber, int pageSize)
        {
            var patientsWithEventCounts = _dbContext.Patients
                    .OrderBy(p => p.Id) // Order the persons by ID
                    .Skip((pageNumber - 1) * pageSize) // Skip records based on the selected page
                    .Take(pageSize) // Retrieve the specified number of records for the page
                    .Select(p => new
                    {
                        Patient = p,
                        EventCount = _dbContext.Events.Count(e => e.PatientId == p.Id),
                        Device=_dbContext.Devices.First(d=>d.Id==p.DeviceId)
                    })
                    .ToList();

            if (patientsWithEventCounts == null || patientsWithEventCounts.Count == 0)
                return null;

            List<PatientDetail> patientDetails= new List<PatientDetail>();  
            foreach(var patient in patientsWithEventCounts)
            {
                patientDetails.Add(new PatientDetail()
                {
                    Id = patient.Patient.Id,
                    Name = patient.Patient.Name,
                    DateOfBirth = patient.Patient.DateOfBirth,
                    DeviceSerialNumber = patient.Device.SerialNumber,
                    StudyEndTime = patient.Patient.StudyEndTime,
                    StudyStartTime = patient.Patient.StudyStartTime,
                    TotalNumberOfEvents = patient.EventCount
                });
            }

            return patientDetails;
        }

        public Patient GetPatient   (long patientId)
        {
            return _dbContext.Patients.FirstOrDefault();
        }
    }
}