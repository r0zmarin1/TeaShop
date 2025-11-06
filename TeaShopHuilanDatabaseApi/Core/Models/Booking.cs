namespace TeaShopHuilanDatabaseApi.Core.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HoursCount { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
