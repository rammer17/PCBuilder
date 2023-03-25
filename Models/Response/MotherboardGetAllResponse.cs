using PCBuilder.Models.DB;

namespace PCBuilder.Models.Request
{
    public class MotherboardGetAllResponse
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FormFactor { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public int MaxMemorySpeed { get; set; }
        public bool Wifi { get; set; }
    }
}
