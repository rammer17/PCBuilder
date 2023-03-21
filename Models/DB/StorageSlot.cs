﻿namespace PCBuilder.Models.DB
{
    public class StorageSlot
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        // n:n relationship with Motherboard
        public ICollection<Motherboard> Motherboards { get; set; }
    }
}
