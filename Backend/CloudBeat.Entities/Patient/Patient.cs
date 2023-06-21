namespace CloudBeat.Entities
{
    public class Patient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StudyStartTime { get; set; }
        public DateTime StudyEndTime { get; set; }
        public int DeviceId { get; set; }
    }
}