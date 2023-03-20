namespace PCBuilder.Models.DB
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FormFactor { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public int MaxMemorySpeed { get; set; }
        public bool Wifi { get; set; }
        public ICollection<Port> Ports { get; set; }
        public ICollection<StorageSlot> StorageSlots { get; set; }
        public ICollection<CPU> CompatibleCpus { get; set; }
        public ICollection<RAM> CompatibleRam { get; set; }
        public ICollection<GPU> CompatibleGpus { get; set; }
        public ICollection<Case> CompatibleCases { get; set; }



    }
}
