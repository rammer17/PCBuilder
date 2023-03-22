namespace PCBuilder.Models.DB
{
    public class Port
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // n:n relationship with Motherboard
        public ICollection<Motherboard> Motherboards { get; set; }
    }
}
