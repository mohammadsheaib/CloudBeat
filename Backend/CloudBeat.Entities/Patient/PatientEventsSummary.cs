namespace CloudBeat.Entities
{
    public class PatientEventsSummary
    {
        public string PatientName { get; set; }
        public List<EventDetail> EventDetails { get; set; }
        public int MaxBPM { get; set; }
        public int MinBPM { get; set; }
        public decimal AverageBPM { get; set; }
    }
}