namespace PCBuilder.Models.Request.Compatible
{
    public class CaseGetCompatibleRequest
    {
        public int MotherboardId { get; set; }
        public int PowerSupplyId { get; set; }
        public int GpuId { get; set; }
    }
}
