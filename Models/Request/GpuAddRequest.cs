namespace PCBuilder.Models.Request
{
    public class GpuAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public int MemoryBus { get; set; }
        public int TDP { get; set; }
    }
}
