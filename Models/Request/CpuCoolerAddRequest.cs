namespace PCBuilder.Models.Request
{
    public class CpuCoolerAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public int TDP { get; set; }
        public List<int> SocketIds { get; set; }
        public int MaxRPM { get; set; }
        public int NoiseLevel { get; set; }
    }
}
