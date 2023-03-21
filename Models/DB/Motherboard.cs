namespace PCBuilder.Models.DB
{
    public class Motherboard
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FormFactor { get; set; }
        // 1:n relationship with Socket
        public int? SocketId { get; set; }
        public Socket Socket { get; set; }
        // 1:n relationship with Chipset
        public Chipset Chipset { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public int MaxMemorySpeed { get; set; }
        public bool Wifi { get; set; }
        // n:n relationship with CPU
        public ICollection<CPU> CompatibleCpus { get; set; }
        // n:n relationship with RAM
        public ICollection<RAM> CompatibleRam { get; set; }
        // n:n relationship with Case
        public ICollection<Case> CompatibleCases { get; set; }
        // n:n relationship with Port
        public ICollection<Port> BackPanelPorts { get; set; }
        // n:n relationship with Internal Connector
        public ICollection<InternalConnector> InternalConnectors { get; set; }
        // n:n relationship with StorageSlots
        public ICollection<StorageSlot> StorageSlots { get; set; }



    }
}
