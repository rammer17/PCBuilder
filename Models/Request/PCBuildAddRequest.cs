namespace PCBuilder.Models.Request
{
    public class PCBuildAddRequest
    {
        public int CpuId { get; set; }
        public int CpuCoolerId { get; set; }
        public int MotherboardId { get; set; }
        public int RamId { get; set; }
        public int StorageId { get; set; }
        public int GpuId { get; set; }
        public int CaseId { get; set; }
        public int PowerSupplyId { get; set; }
    }
}
