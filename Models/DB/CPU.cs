namespace PCBuilder.Models.DB
{
    public class CPU
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        // 1:n relationship with Socket
        public Socket Socket { get; set; }
        // n:n relationship with Motherboard
        public List<Motherboard> CompatibleMotherboards { get; set; }
        // n:n relationship with CpuCooler
        public List<CPUCooler> CompatibleCpuCoolers { get; set; }
    }
}
