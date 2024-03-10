namespace HieuVeBan.Models.QueryParam
{
    public class ProvinceQueryParams : QueryParams
    {
        public int? AdministrativeUnitId { get; set; }
        public int? AdministrativeRegionId { get; set; }
        public string? Search { get; set; }
    }
}