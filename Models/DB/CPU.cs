namespace PCBuilder.Models.DB
{
    public class CPU
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double MaxBoostClock { get; set; }
        public string Socket { get; set; }
        public ICollection<Motherboard> CompatibleMotherboards { get; set; }
        public ICollection<CPUCooler> CompatibleCpuCoolers { get; set; }
        public ICollection<RAM> CompatibleRam { get; set; }



    }
}
