using PCBuilder.Models.DB;

namespace PCBuilder.Models.Response
{
    public class CpuCoolerGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int TDP { get; set; }
        public List<string> Sockets { get; set; }
        public int MaxRPM { get; set; }
        public int NoiseLevel { get; set; }
    }
}
