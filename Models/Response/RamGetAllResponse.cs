namespace PCBuilder.Models.Response
{
    public class RamGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Frequency { get; set; }
        public string Type { get; set; }
        public string Timing { get; set; }
    }
}
