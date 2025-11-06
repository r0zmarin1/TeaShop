namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReportTypeId { get; set; }
        public string Path { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
