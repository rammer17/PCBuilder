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
        // n:n relationship with Case
        public ICollection<Case> CompatibleCases { get; set; }


    }
}
