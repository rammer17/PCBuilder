namespace PCBuilder.Models.Request
{
    public class MotherboardAddRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FormFactor { get; set; }
        public int SocketId { get; set; }
        public int ChipsetId { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public int MaxMemorySpeed { get; set; }
        public bool Wifi { get; set; }
        public List<int> PortIds { get; set; }
        public List<int> ConnectorIds { get; set; }
        public List<int> StorageSlotIds { get; set; }
    }
}
