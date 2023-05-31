namespace PCBuilder.Models.Request
{
    public class CpuAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        public string ImageUrl { get; set; }
        public int SocketId { get; set; }

    }
}
