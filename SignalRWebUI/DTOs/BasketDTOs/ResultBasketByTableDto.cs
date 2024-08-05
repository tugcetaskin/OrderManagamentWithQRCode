using EntityLayer.Entities;

namespace SignalRWebUI.DTOs.BasketDTOs
{
    public class ResultBasketByTableDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TableId { get; set; }
        public TableForCustomer Table { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
