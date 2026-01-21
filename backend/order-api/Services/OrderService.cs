using order_api.Data;
using order_api.Models;
using order_api.Repositories;

namespace order_api.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        AppDbContext context,
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _context = context;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public async Task<(bool Success, string Message)> PlaceOrderAsync(int productId, int quantity)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Check product exists
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                return (false, "Product not found");

            // Check stock
            if (product.Stock < quantity)
                return (false, "Insufficient stock");

            //  Reduce stock
            product.Stock -= quantity;

            // Create order
            var order = new Order
            {
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = product.Price * quantity,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Update(product);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

          
            await transaction.CommitAsync();

            return (true, "Order placed successfully");
        }
        catch
        {
            await transaction.RollbackAsync();
            return (false, "Order failed");
        }
    }
}
