namespace PCBuilder.Models.DB
{
    public class Case
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string MotherboardFormFactor { get; set; }
        // n:n relationship with Motherboard
        public ICollection<Motherboard> CompatibleMotherboards { get; set; }
        // n:n relationship with PowerSupply
        public ICollection<PowerSupply> CompatiblePowerSupplies { get; set; }
        // n:n relationship with Storage
        public ICollection<Storage> CompatibleStorages { get; set; }
        // n:n relationship with GPU
        public ICollection<GPU> CompatibleGpus { get; set; }

    }
}
