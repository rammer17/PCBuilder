using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;

namespace PCBuilder
{
    public class PCBuilderDbContext : DbContext
    {
        public PCBuilderDbContext(DbContextOptions<PCBuilderDbContext> options) : base(options) { }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CPUCooler> CPUCoolers { get; set; }
        public DbSet<Motherboard> MotherBoards { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<RAM> Memories { get; set; }
        public DbSet<StorageSlot> StorageSlots { get; set; }
        public DbSet<Socket> Sockets { get; set; }



    }
}
