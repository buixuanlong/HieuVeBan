namespace HieuVeBan.Models.Commands.QueryParams
{
    public class ProvinceQueryParams : System.Collections.Generic.QueryParams
    {
        public int? AdministrativeUnitId { get; set; }
        public int? AdministrativeRegionId { get; set; }
        public string? Search { get; set; }
    }
}