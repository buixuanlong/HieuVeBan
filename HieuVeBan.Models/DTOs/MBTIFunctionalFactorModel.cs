namespace HieuVeBan.Models.DTOs
{
    public class MBTIFunctionalFactorModel
    {
        public string Name { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string Symbol { get; set; } = null!;

        public IEnumerable<MBTIFunctionalFactorNameDetailModel> MBTIFunctionalFactorNameDetails { get; set; } = new List<MBTIFunctionalFactorNameDetailModel>();
    }
}
