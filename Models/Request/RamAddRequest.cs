namespace PCBuilder.Models.Request
{
    public class RamAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Frequency { get; set; }
        public string Type { get; set; }
        public string Timing { get; set; }
    }
}
