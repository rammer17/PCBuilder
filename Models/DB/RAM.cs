namespace PCBuilder.Models.DB
{
    public class RAM
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Frequency { get; set; }
        public string Type { get; set; }
        public string Timing { get; set; }
        // n:n relationship with Motherboard
        public ICollection<Motherboard> CompatibleMotherboards { get; set; }
        public ICollection<CPU> CompatibleCpus { get; set; }

    }
}
