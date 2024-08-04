namespace ServiceCheck.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int SortNumber { get; set; }
        public bool AutomaticRestart { get; set; }
        public bool StartMessage { get; set; }
        public bool StopMessage { get; set; }
    }
}
