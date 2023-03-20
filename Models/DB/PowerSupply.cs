namespace PCBuilder.Models.DB
{
    public class PowerSupply
    {
        public int Id { get; set; }
        public string Manufactorer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string EfficiencyRating { get; set; }
        public string FormFactor { get; set; }
        public int Wattage { get; set; }
        public ICollection<Port> Connectors { get; set; }
    }
}
