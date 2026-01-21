namespace order_api.Models;

public class OrderRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
