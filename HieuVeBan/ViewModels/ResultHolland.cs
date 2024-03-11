namespace HieuVeBan.ViewModels
{
    public class ResultHolland
    {
        public string JobType { get; set; }
        public int Total { get; set; }
        public ResultHolland(string jobType, int total)
        {
            JobType = jobType;
            Total = total;
        }
    }
}
