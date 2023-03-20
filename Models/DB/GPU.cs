namespace PCBuilder.Models.DB
{
    public class GPU
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public int MemoryBus { get; set; }
        public int TDP { get; set; }
        public ICollection<Motherboard> CompatibleMotherboards { get; set; }
        public ICollection<PowerSupply> CompatiblePowerSupplies { get; set; }
        public ICollection<Case> CompatibleCases { get; set; }


    }
}
