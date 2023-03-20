namespace PCBuilder.Models.DB
{
    public class Case
    {
        public int Id { get; set; }
        public string Manufactorer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string MotherboardFormFactor { get; set; }
        public ICollection<Motherboard> CompatibleMotherboards { get; set; }
        public ICollection<PowerSupply> CompatiblePowerSupplies { get; set; }
        public ICollection<StorageSlot> CompatibleStorageSlots { get; set; }
    }
}
