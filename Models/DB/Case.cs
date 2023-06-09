namespace PCBuilder.Models.DB
{
    public class Case
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string FormFactor { get; set; }
        public int MaxGpuHeight { get; set; }
        public int MaxGpuWidth { get; set; }
        // n:n relationship with Motherboard
        public List<Motherboard> CompatibleMotherboards { get; set; }
        // n:n relationship with PowerSupply
        public List<PowerSupply> CompatiblePowerSupplies { get; set; }
        // n:n relationship with GPU
        public List<GPU> CompatibleGpus { get; set; }

    }
}
