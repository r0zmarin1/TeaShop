namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class Order
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Cost { get; set; }
    }
}
