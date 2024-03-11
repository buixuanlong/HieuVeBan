namespace HieuVeBan.Models.OldModel
{
    public class Result_Holland
    {
        public string JobType { get; set; }
        public int Total { get; set; }
        public Result_Holland(string jobType, int total)
        {
            JobType = jobType;
            Total = total;
        }
    }
}
