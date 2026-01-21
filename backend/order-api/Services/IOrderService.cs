namespace order_api.Services;

public interface IOrderService
{
    Task<(bool Success, string Message)> PlaceOrderAsync(int productId, int quantity);
}
