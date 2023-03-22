namespace PCBuilder.Models.Response
{
    public class PowerSupplyGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string EfficiencyRating { get; set; }
        public string FormFactor { get; set; }
        public int Wattage { get; set; }
    }
}
