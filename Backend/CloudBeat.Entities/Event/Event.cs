namespace CloudBeat.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public int DeviceId { get; set; }
        public int PatientId { get; set; }
        public int BPM { get; set; }
        public DateTime Date { get; set; }
    }
}