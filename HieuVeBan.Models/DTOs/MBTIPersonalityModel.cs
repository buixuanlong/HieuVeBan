namespace HieuVeBan.Models.DTOs
{
    public class MBTIPersonalityModel
    {
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IEnumerable<MBTICelebrityModel> Celebrities { get; set; } = new List<MBTICelebrityModel>();
        public IEnumerable<MBTIFunctionalFactorModel> FunctionalFactors { get; set; } = new List<MBTIFunctionalFactorModel>();

    }
}
