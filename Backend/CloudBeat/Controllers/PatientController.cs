using Microsoft.AspNetCore.Mvc;
using CloudBeat.Business;
using CloudBeat.Entities;
using Newtonsoft.Json;

namespace CloudBeat.Controllers
{
    [ApiController]
    [Route("api/PatientController")]
    public class PatientController : ControllerBase
    {
        PatientManager _patientManager;
        public PatientController(PatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [Route("GetPatientsDetails")]
        [HttpGet]
        public List<PatientDetail> GetPatientsDetails(int pageNumber, int pageSize)
        {
            return _patientManager.GetPatientsDetails(pageNumber, pageSize);
        }

        [Route("GetPatientEventsSummary")]
        [HttpGet]
        public PatientEventsSummary GetPatientEventsSummary(long patientId)
        {
            return _patientManager.GetPatientEventsSummary(patientId);
        }
    }
}
