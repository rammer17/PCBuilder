﻿namespace PCBuilder.Models.DB
{
    public class CPUCooler
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int TDP { get; set; }
        // n:n relationship with Socket
        public ICollection<Socket> Sockets { get; set; }
        public int MaxRPM { get; set; }
        public int NoiseLevel { get; set; }
        // n:n relationship with CPU
        public ICollection<CPU> CompatibleCpus { get; set; }

    }
}
