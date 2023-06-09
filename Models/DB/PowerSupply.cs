namespace PCBuilder.Models.DB
{
    public class PowerSupply
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string EfficiencyRating { get; set; }
        public string FormFactor { get; set; }
        public int Wattage { get; set; }
        // n:n relationship with InternalConnector
        public ICollection<InternalConnector> Connectors { get; set; }
        // n:n relationship with Case
        public List<Case> CompatibleCases { get; set; }
    }
}
