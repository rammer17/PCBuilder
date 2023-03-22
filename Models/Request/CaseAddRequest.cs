namespace PCBuilder.Models.Request
{
    public class CaseAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string MotherboardFormFactor { get; set; }
    }
}
