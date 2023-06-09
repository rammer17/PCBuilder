namespace PCBuilder.Models.DB
{
    public class Storage
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string FormFactor { get; set; }
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        public string Interface { get; set; }

    }
}
