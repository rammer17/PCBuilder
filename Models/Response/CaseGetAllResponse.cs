namespace PCBuilder.Models.Response
{
    public class CaseGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string FormFactor { get; set; }
        public int MaxGpuHeight { get; set; }
        public int MaxGpuWidth { get; set; }
    }
}
