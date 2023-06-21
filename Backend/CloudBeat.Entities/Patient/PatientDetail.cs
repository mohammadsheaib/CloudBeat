namespace CloudBeat.Entities
{
    public class PatientDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StudyStartTime { get; set; }
        public DateTime StudyEndTime { get; set; }
        public string DeviceSerialNumber { get; set; }
        public int TotalNumberOfEvents { get; set; }
    }
}