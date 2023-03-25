namespace PCBuilder.Models.Request.Compatible
{
    public class MotherboardGetCompatibleRequest
    {
        public int CpuId { get; set; }
        public int RamId { get; set; }
        public int CaseId { get; set; }
    }
}
