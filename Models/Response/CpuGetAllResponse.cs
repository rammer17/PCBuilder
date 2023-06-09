using PCBuilder.Models.DB;

namespace PCBuilder.Models.Response
{
    public class CpuGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        public string Socket { get; set; }
    }
}
