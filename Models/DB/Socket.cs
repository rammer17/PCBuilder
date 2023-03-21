namespace PCBuilder.Models.DB
{
    public class Socket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // n:n relationship with CpuCooler
        public ICollection<CPUCooler> CPUCoolers { get; set; }
    }
}
